using System.Threading;
using System.Threading.Tasks;
using Tsukumo.StableDiffusion.Models;

namespace Tsukumo.StableDiffusion.Interfaces
{
    /// <summary>
    /// Defines the interface for Stable Diffusion text-to-image service operations.
    /// </summary>
    public interface ITxt2ImgService
    {
        /// <summary>
        /// Generates an image from text using Stable Diffusion.
        /// </summary>
        /// <param name="request">The text-to-image processing request containing prompt and parameters.</param>
        /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous image generation operation.</returns>
        Task<TextToImageResponse> GenerateAsync(StableDiffusionProcessingTxt2Img request, CancellationToken cancellationToken);
    }
}
