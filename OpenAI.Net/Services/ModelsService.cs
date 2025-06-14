using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tsukumo.OpenAI.Interfaces;
using Tsukumo.OpenAI.Models.Models;

namespace Tsukumo.OpenAI.Services;

public class ModelsService : IModelsService
{
    public ModelsService(string endpoint, string? apiKey) {
        _requestUri = $"{endpoint}/{_api}";
        _apiKey = apiKey;
    }

    public async Task<ListModelsResponse?> ListModels(CancellationToken cancellationToken = default) {
        using var client = new HttpClient();
        if (_apiKey != null) client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        var httpResponseMessage = await client.GetAsync(_requestUri);
        var responseJson = await httpResponseMessage.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<ListModelsResponse>(responseJson);
    }

    const string _api = "models";
    readonly string _requestUri;
    readonly string? _apiKey;
}
