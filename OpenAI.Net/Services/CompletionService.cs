using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tsukumo.OpenAI.Interfaces;
using Tsukumo.OpenAI.Models.Completion;

namespace Tsukumo.OpenAI.Services;

public class CompletionService : ICompletionService
{
    public CompletionService(string endpoint, string? apiKey) {
        _requestUri = $"{endpoint}/{_api}";
        _apiKey = apiKey;
    }

    public async Task<Response?> CreateCompletion(
        Request request,
        string? modelId = null,
        CancellationToken cancellationToken = default) {
        request.Stream = false;
        using var client = new HttpClient();
        if (_apiKey != null) client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        var requestJson = JsonConvert.SerializeObject(request);
        var httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
        var httpResponseMessage = await client.PostAsync(_requestUri, httpContent, cancellationToken);
        var responseJson = await httpResponseMessage.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Response>(responseJson);
    }

    public async IAsyncEnumerable<Response?> CreateCompletionAsStream(
        Request request,
        string? modelId = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default) {

        request.Stream = true;
        using var client = new HttpClient();
        if (_apiKey != null) client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

        var requestJson = JsonConvert.SerializeObject(request);
        var httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, _requestUri);
        httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/event-stream"));
        httpRequestMessage.Content = httpContent;

        var httpResponseMessage = await client.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        await using var stream = await httpResponseMessage.Content.ReadAsStreamAsync();
        using var reader = new StreamReader(stream);
        while (true) {
            cancellationToken.ThrowIfCancellationRequested();
            var line = await reader.ReadLineAsync();
            if (line == null) break;
            if (string.IsNullOrEmpty(line)) continue;
            var data = line.StartsWith(_data, StringComparison.Ordinal) ? line[_data.Length..] : line;
            if (data == _done) break;
            var block = JsonConvert.DeserializeObject<Response>(data);
            if (block != null) yield return block;
        }
    }

    const string _api = "completions";
    const string _data = "data: ", _done = "[DONE]";
    readonly string _requestUri;
    readonly string? _apiKey;
}
