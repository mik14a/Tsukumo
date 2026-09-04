using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Tsukumo.ComfyUI.Interfaces;
using Tsukumo.ComfyUI.Models;

namespace Tsukumo.ComfyUI.Services;

public class PromptService : IPromptService, IDisposable
{
    public PromptService(string endpoint, Workflow workflow, string promptNodeId, string negativePromptNodeId, string negativePrompt) {
        _endpoint = endpoint;
        Workflow = workflow ?? throw new ArgumentNullException(nameof(workflow));
        PromptNodeId = RequireNode(promptNodeId, nameof(promptNodeId));
        NegativePromptNodeId = RequireNode(negativePromptNodeId, nameof(negativePromptNodeId));
        NegativePrompt = negativePrompt;
        _httpClient = HttpClientFactory.CreateHttpClient();
        _httpClient.DefaultRequestHeaders.ConnectionClose = false;

        string RequireNode(string nodeId, string paramName) {
            if (string.IsNullOrEmpty(nodeId))
                throw new ArgumentException("Node id is required.", paramName);
            if (workflow.Graph[nodeId] is not JObject node)
                throw new InvalidOperationException($"Node '{nodeId}' not found.");
            if (node["inputs"] is not JObject)
                throw new InvalidOperationException($"Node '{nodeId}' has no inputs.");
            return nodeId;
        }
    }

    public Workflow Workflow { get; }
    public string PromptNodeId { get; }
    public string NegativePromptNodeId { get; }
    public string NegativePrompt { get; }

    public async Task<IReadOnlyList<byte[]>> GenerateAsync(string prompt, CancellationToken cancellationToken = default) {
        Workflow.SetInput(PromptNodeId, _textInput, prompt);
        Workflow.SetInput(NegativePromptNodeId, _textInput, NegativePrompt);
        var promptId = await Queue();
        var images = await Wait();
        var result = new List<byte[]>(images.Count);
        foreach (var image in images)
            result.Add(await View(image));
        return result;

        async Task<string> Queue() {
            var body = new JObject { ["prompt"] = Workflow.Graph.DeepClone() };
            using var httpContent = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
            using var httpResponseMessage = await _httpClient.PostAsync($"{_endpoint}/prompt", httpContent, cancellationToken);
            var responseJson = await ReadString(httpResponseMessage);
            var response = JObject.Parse(responseJson);
            if (!httpResponseMessage.IsSuccessStatusCode || response["error"] != null)
                throw new HttpRequestException($"POST /prompt failed: {(int)httpResponseMessage.StatusCode} {responseJson}");
            if (response["node_errors"] is JObject nodeErrors && nodeErrors.Count > 0)
                throw new InvalidOperationException($"ComfyUI node errors: {nodeErrors}");
            var id = (string?)response["prompt_id"];
            if (string.IsNullOrEmpty(id))
                throw new InvalidOperationException($"ComfyUI returned no prompt_id: {responseJson}");
            return id;
        }

        async Task<List<ImageRef>> Wait() {
            while (true) {
                cancellationToken.ThrowIfCancellationRequested();
                using var httpResponseMessage = await _httpClient.GetAsync($"{_endpoint}/history/{promptId}", cancellationToken);
                var historyJson = await ReadString(httpResponseMessage);
                if (!httpResponseMessage.IsSuccessStatusCode)
                    throw new HttpRequestException($"GET /history/{promptId} failed: {(int)httpResponseMessage.StatusCode} {historyJson}");
                var history = JObject.Parse(historyJson);
                if (history[promptId] is JObject entry && IsComplete(entry))
                    return ReadImages(entry);
                await Task.Delay(_pollIntervalMs, cancellationToken);
            }
        }

        async Task<byte[]> View(ImageRef image) {
            var uri = $"{_endpoint}/view?filename={Uri.EscapeDataString(image.Filename)}&subfolder={Uri.EscapeDataString(image.Subfolder)}&type={Uri.EscapeDataString(image.Type)}";
            using var httpResponseMessage = await _httpClient.GetAsync(uri, cancellationToken);
            if (!httpResponseMessage.IsSuccessStatusCode) {
                var body = await ReadString(httpResponseMessage);
                throw new HttpRequestException($"GET /view failed: {(int)httpResponseMessage.StatusCode} {body}");
            }
#if NET5_0_OR_GREATER
            return await httpResponseMessage.Content.ReadAsByteArrayAsync(cancellationToken);
#else
            return await httpResponseMessage.Content.ReadAsByteArrayAsync();
#endif
        }

        bool IsComplete(JObject entry) {
            if (entry["status"] is not JObject status)
                return true;
            var statusStr = (string?)status["status_str"];
            if (string.Equals(statusStr, "error", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException($"ComfyUI execution failed for {promptId}: {status["messages"]}");
            if (status["completed"] is JToken completed)
                return completed.Value<bool>();
            return true;
        }

        List<ImageRef> ReadImages(JObject entry) {
            var images = new List<ImageRef>();
            if (entry["outputs"] is not JObject outputs)
                return images;
            foreach (var node in outputs.Properties()) {
                if (node.Value["images"] is not JArray imageArray)
                    continue;
                foreach (var token in imageArray) {
                    var filename = (string?)token["filename"];
                    if (filename == null)
                        throw new InvalidOperationException($"ComfyUI image output is missing filename: {token}");
                    images.Add(new ImageRef(
                        filename,
                        (string?)token["subfolder"] ?? string.Empty,
                        (string?)token["type"] ?? "output"));
                }
            }
            return images;
        }

        async Task<string> ReadString(HttpResponseMessage httpResponseMessage) {
#if NETCOREAPP3_0_OR_GREATER
            return await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
#else
            return await httpResponseMessage.Content.ReadAsStringAsync();
#endif
        }
    }

    public void Dispose() {
        _httpClient?.Dispose();
        GC.SuppressFinalize(this);
    }

    const string _textInput = "text";
    const int _pollIntervalMs = 500;
    readonly string _endpoint;
    readonly HttpClient _httpClient;

    readonly struct ImageRef
    {
        public ImageRef(string filename, string subfolder, string type) {
            Filename = filename;
            Subfolder = subfolder;
            Type = type;
        }

        public string Filename { get; }
        public string Subfolder { get; }
        public string Type { get; }
    }
}
