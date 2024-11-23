using System.Threading;
using System.Threading.Tasks;
using StableDiffusion.Models;

namespace StableDiffusion.Interfaces
{
    public interface ITxt2ImgService
    {
        Task<TextToImageResponse> GenerateAsync(StableDiffusionProcessingTxt2Img request, CancellationToken cancellationToken);
    }
}
