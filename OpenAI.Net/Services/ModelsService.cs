using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tsukumo.OpenAI.Interfaces;
using Tsukumo.OpenAI.Models.Models;

namespace Tsukumo.OpenAI.Services;

public class ModelsService : IModelsService, IDisposable
{
    public ModelsService(string endpoint, string? apiKey) {
        _requestUri = $"{endpoint}/{_api}";
        _apiKey = apiKey;
        _httpClient = HttpClientFactory.CreateHttpClient();
        _httpClient.DefaultRequestHeaders.ConnectionClose = false;
        if (_apiKey != null) {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }
    }

    public async Task<ListModelsResponse?> ListModels(CancellationToken cancellationToken = default) {
        var httpResponseMessage = await _httpClient.GetAsync(_requestUri);
#if NETCOREAPP3_0_OR_GREATER
        var responseJson = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
#else
        var responseJson = await httpResponseMessage.Content.ReadAsStringAsync();
#endif
        return JsonConvert.DeserializeObject<ListModelsResponse>(responseJson);
    }

    public void Dispose() {
        _httpClient?.Dispose();
        GC.SuppressFinalize(this);
    }

    const string _api = "models";
    readonly string _requestUri;
    readonly string? _apiKey;
    readonly HttpClient _httpClient;
}
