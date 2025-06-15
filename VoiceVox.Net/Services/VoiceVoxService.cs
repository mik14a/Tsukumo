using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Tsukumo.VoiceVox.Interfaces;

namespace Tsukumo.VoiceVox.Services;

public class VoiceVoxService : IVoiceVoxService
{
    public VoiceVoxService(string endpoint) {
        _endpoint = endpoint;
    }

    public async Task<Stream> Speak(string text, string speaker, float speedScale, CancellationToken cancellationToken) {
        using var httpClient = new HttpClient();
        var query = await AudioQuery(httpClient, text, speaker, cancellationToken);
        return query != null ? await Synthesis(httpClient, query, speaker, speedScale, cancellationToken)
                             : Stream.Null;
    }

    async Task<string?> AudioQuery(HttpClient httpClient, string text, string speaker, CancellationToken cancellationToken) {
        using var request = new HttpRequestMessage(HttpMethod.Post, $"{_endpoint}/audio_query?text={text}&speaker={speaker}");
        request.Headers.TryAddWithoutValidation("accept", "application/json");
        request.Content = new StringContent(string.Empty);
        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
        try {
            var response = await httpClient.SendAsync(request, cancellationToken);
            return response.Content.ReadAsStringAsync().Result;
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString());
        }
        return null;
    }

    async Task<Stream> Synthesis(HttpClient httpClient, string query, string speaker, float speedScale, CancellationToken cancellationToken) {
        var json = JObject.Parse(query);
        json["speedScale"] = speedScale;
        using var request = new HttpRequestMessage(HttpMethod.Post, $"{_endpoint}/synthesis?speaker={speaker}&enable_interrogative_upspeak=true");
        request.Headers.TryAddWithoutValidation("accept", "audio/wav");
        request.Content = new StringContent(json.ToString());
        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        try {
            var response = await httpClient.SendAsync(request, cancellationToken);
            return await response.Content.ReadAsStreamAsync();
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString());
        }
        return Stream.Null;
    }

    /// <summary>Endpoint of the VoiceVox API</summary>
    readonly string _endpoint;
}
