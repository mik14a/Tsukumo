using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Tsukumo.Core;
using Tsukumo.VoiceVox.Interfaces;

namespace Tsukumo.VoiceVox.Services;

public class VoiceVoxService : IVoiceVoxService, IDisposable
{
    public VoiceVoxService(string endpoint) {
        _endpoint = endpoint;
        _httpClient = HttpClientFactory.CreateHttpClient();
        _httpClient.DefaultRequestHeaders.ConnectionClose = false;
    }

    public async Task<Stream> Speak(string text, string speaker, float speedScale, CancellationToken cancellationToken) {
        var query = await AudioQuery(text, speaker, cancellationToken);
        return query != null ? await Synthesis(query, speaker, speedScale, cancellationToken)
                             : Stream.Null;
    }

    async Task<string?> AudioQuery(string text, string speaker, CancellationToken cancellationToken) {
        using var request = new HttpRequestMessage(HttpMethod.Post, $"{_endpoint}/audio_query?text={text}&speaker={speaker}");
        request.Headers.TryAddWithoutValidation("accept", "application/json");
        request.Content = new StringContent(string.Empty);
        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
        try {
            var response = await _httpClient.SendAsync(request, cancellationToken);
#if NETCOREAPP3_0_OR_GREATER
            return await response.Content.ReadAsStringAsync(cancellationToken);
#else
            return await response.Content.ReadAsStringAsync();
#endif
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString());
        }
        return null;
    }

    async Task<Stream> Synthesis(string query, string speaker, float speedScale, CancellationToken cancellationToken) {
        var json = JObject.Parse(query);
        json["speedScale"] = speedScale;
        using var request = new HttpRequestMessage(HttpMethod.Post, $"{_endpoint}/synthesis?speaker={speaker}&enable_interrogative_upspeak=true");
        request.Headers.TryAddWithoutValidation("accept", "audio/wav");
        request.Content = new StringContent(json.ToString());
        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        try {
            var response = await _httpClient.SendAsync(request, cancellationToken);
            return await response.Content.ReadAsStreamAsync();
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString());
        }
        return Stream.Null;
    }

    public void Dispose() {
        _httpClient?.Dispose();
        GC.SuppressFinalize(this);
    }

    /// <summary>Endpoint of the VoiceVox API</summary>
    readonly string _endpoint;
    readonly HttpClient _httpClient;
}
