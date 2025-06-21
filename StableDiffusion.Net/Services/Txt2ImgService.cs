using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tsukumo.Core;
using Tsukumo.StableDiffusion.Interfaces;
using Tsukumo.StableDiffusion.Models;

namespace Tsukumo.StableDiffusion.Services;

public class Txt2ImgService : ITxt2ImgService, IDisposable
{
    public Txt2ImgService(string endpoint) {
        _requestUri = $"{endpoint}/{_api}";
        _httpClient = HttpClientFactory.CreateHttpClient();
        _httpClient.DefaultRequestHeaders.ConnectionClose = false;
    }

    public async Task<TextToImageResponse?> GenerateAsync(StableDiffusionProcessingTxt2Img request, CancellationToken cancellationToken = default) {

        var requestJson = JsonConvert.SerializeObject(request);
        using var httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
        using var httpResponseMessage = await _httpClient.PostAsync(_requestUri, httpContent, cancellationToken);
#if NETCOREAPP3_0_OR_GREATER
        var responseJson = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
#else
        var responseJson = await httpResponseMessage.Content.ReadAsStringAsync();
#endif
        var result = JsonConvert.DeserializeObject<TextToImageResponse>(responseJson);
        return result;
    }

    public void Dispose() {
        _httpClient?.Dispose();
        GC.SuppressFinalize(this);
    }

    const string _api = "txt2img";
    readonly string _requestUri;
    readonly HttpClient _httpClient;
}
