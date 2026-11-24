using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tsukumo;
using Tsukumo.OpenAI.Interfaces;
using Tsukumo.OpenAI.Models.Embedding;

namespace Tsukumo.OpenAI.Services;

public class EmbeddingService : IEmbeddingService, IDisposable
{
    public string RequestUri => _requestUri;

    public EmbeddingService(string endpoint, string? apiKey) {
        _requestUri = $"{endpoint.TrimEnd('/')}/{_api}";
        _httpClient = HttpClientFactory.CreateHttpClient();
        _httpClient.Timeout = TimeSpan.FromMinutes(5);
        _httpClient.DefaultRequestHeaders.ConnectionClose = false;
        if (apiKey != null) {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        }
        _jsonSettings = new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        };
    }

    public async Task<Response> CreateEmbedding(Request request, CancellationToken cancellationToken = default) {
        var requestJson = JsonConvert.SerializeObject(request, _jsonSettings);
        using var httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
        using var httpResponseMessage = await _httpClient.PostAsync(_requestUri, httpContent, cancellationToken);
#if NETCOREAPP3_0_OR_GREATER
        var responseJson = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
#else
        var responseJson = await httpResponseMessage.Content.ReadAsStringAsync();
#endif
        var response = JsonConvert.DeserializeObject<Response>(responseJson, _jsonSettings);
        if (response == null) {
            return new Response { Error = new Tsukumo.OpenAI.Models.Error { Message = responseJson } };
        }
        if (httpResponseMessage.IsSuccessStatusCode) return response;
        response.Error ??= new Tsukumo.OpenAI.Models.Error { Message = responseJson };
        return response;
    }

    public void Dispose() {
        _httpClient?.Dispose();
        GC.SuppressFinalize(this);
    }

    const string _api = "embeddings";
    readonly string _requestUri;
    readonly HttpClient _httpClient;
    readonly JsonSerializerSettings _jsonSettings;
}
