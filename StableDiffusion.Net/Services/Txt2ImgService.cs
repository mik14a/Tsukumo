using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tsukumo.Interfaces;
using Tsukumo.StableDiffusion.Models;

namespace Tsukumo.StableDiffusion.Services;

public class Txt2ImgService : ITxt2ImgService, IDisposable
{
    public Txt2ImgService(string endpoint,
                          string negativePrompt,
                          int? seed,
                          int? steps,
                          string samplerName,
                          string scheduler) {
        _requestUri = $"{endpoint}/{_api}";
        _negativePrompt = negativePrompt;
        _seed = seed;
        _steps = steps;
        _samplerName = samplerName;
        _scheduler = scheduler;
        _httpClient = HttpClientFactory.CreateHttpClient();
        _httpClient.DefaultRequestHeaders.ConnectionClose = false;
        _jsonSettings = new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore
        };
    }

    public async Task<IReadOnlyList<byte[]>> GenerateAsync(string prompt, int width, int height, CancellationToken cancellationToken = default) {
        var request = new Txt2ImgRequest {
            Prompt = prompt,
            NegativePrompt = _negativePrompt,
            Seed = _seed,
            Steps = _steps,
            Width = width,
            Height = height,
            SamplerName = _samplerName,
            Scheduler = _scheduler,
        };
        var requestJson = JsonConvert.SerializeObject(request, _jsonSettings);
        using var httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
        using var httpResponseMessage = await _httpClient.PostAsync(_requestUri, httpContent, cancellationToken);
#if NETCOREAPP3_0_OR_GREATER
        var responseJson = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
#else
        var responseJson = await httpResponseMessage.Content.ReadAsStringAsync();
#endif
        var result = JsonConvert.DeserializeObject<Txt2ImgResponse>(responseJson, _jsonSettings);
        if (result?.Images == null)
            return Array.Empty<byte[]>();
        var images = new byte[result.Images.Count][];
        for (var i = 0; i < result.Images.Count; i++)
            images[i] = Convert.FromBase64String(result.Images[i]);
        return images;
    }

    public void Dispose() {
        _httpClient?.Dispose();
        GC.SuppressFinalize(this);
    }

    const string _api = "txt2img";
    readonly string _requestUri;
    readonly string _negativePrompt;
    readonly int? _seed;
    readonly int? _steps;
    readonly string _samplerName;
    readonly string _scheduler;
    readonly HttpClient _httpClient;
    readonly JsonSerializerSettings _jsonSettings;
}
