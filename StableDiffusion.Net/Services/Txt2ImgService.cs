using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tsukumo.StableDiffusion.Interfaces;
using Tsukumo.StableDiffusion.Models;

namespace Tsukumo.StableDiffusion.Services;

public class Txt2ImgService : ITxt2ImgService
{
    public Txt2ImgService(string endpoint) {
        _requestUri = $"{endpoint}/{_api}";
    }

    public async Task<TextToImageResponse?> GenerateAsync(StableDiffusionProcessingTxt2Img request, CancellationToken cancellationToken = default) {

        using var client = new HttpClient();
        var requestJson = JsonConvert.SerializeObject(request);
        using var httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
        using var httpResponseMessage = await client.PostAsync(_requestUri, httpContent, cancellationToken);
#if NETCOREAPP3_0_OR_GREATER
        var responseJson = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
#else
        var responseJson = await httpResponseMessage.Content.ReadAsStringAsync();
#endif
        var result = JsonConvert.DeserializeObject<TextToImageResponse>(responseJson);
        return result;
    }

    const string _api = "txt2img";
    readonly string _requestUri;
}
