using System.Threading;
using System.Threading.Tasks;
using Tsukumo.StableDiffusion.Models;

namespace Tsukumo.StableDiffusion.Interfaces
{
    public interface ITxt2ImgService
    {
        Task<TextToImageResponse> GenerateAsync(StableDiffusionProcessingTxt2Img request, CancellationToken cancellationToken);
    }
}
