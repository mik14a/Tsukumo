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
using Tsukumo.Core;
using Tsukumo.OpenAI.Interfaces;
using Tsukumo.OpenAI.Models.ChatCompletion;

namespace Tsukumo.OpenAI.Services;

public class ChatCompletionService : IChatCompletionService, IDisposable
{
    public string RequestUri => _requestUri;

    public ChatCompletionService(string endpoint, string? apiKey) {
        _requestUri = $"{endpoint}/{_api}";
        _apiKey = apiKey;
        _httpClient = HttpClientFactory.CreateHttpClient();
        _httpClient.DefaultRequestHeaders.ConnectionClose = false;
        if (_apiKey != null) {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }
    }

    public async Task<Response?> CreateChatCompletion(
        Request request,
        TimeSpan timeout,
        CancellationToken cancellationToken = default) {

        request.Stream = false;
        _httpClient.Timeout = timeout;
        var requestJson = JsonConvert.SerializeObject(request);
        var httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
        var httpResponseMessage = await _httpClient.PostAsync(_requestUri, httpContent, cancellationToken);
#if NETCOREAPP3_0_OR_GREATER
        var responseJson = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
#else
        var responseJson = await httpResponseMessage.Content.ReadAsStringAsync();
#endif
        return JsonConvert.DeserializeObject<Response>(responseJson);
    }

    public async IAsyncEnumerable<Response?> CreateChatCompletionAsStream(
        Request request,
        [EnumeratorCancellation] CancellationToken cancellationToken = default) {

        request.Stream = true;
        _httpClient.Timeout = _defaultTimeout;
        var requestJson = JsonConvert.SerializeObject(request);
        var httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, _requestUri);
        httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/event-stream"));
        httpRequestMessage.Content = httpContent;

        var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
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

    public void Dispose() {
        _httpClient?.Dispose();
        GC.SuppressFinalize(this);
    }

    const string _api = "chat/completions";
    const string _data = "data: ", _done = "[DONE]";
    readonly string _requestUri;
    readonly string? _apiKey;
    readonly HttpClient _httpClient;

    static readonly TimeSpan _defaultTimeout = TimeSpan.FromSeconds(100);
}
