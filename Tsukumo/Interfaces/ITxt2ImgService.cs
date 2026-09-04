using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tsukumo.Interfaces
{
    /// <summary>
    /// Defines the interface for text-to-image generation.
    /// </summary>
    public interface ITxt2ImgService
    {
        /// <summary>
        /// Generates images from a text prompt.
        /// </summary>
        /// <param name="prompt">The text prompt used for image generation.</param>
        /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous image generation operation.</returns>
        Task<IReadOnlyList<byte[]>> GenerateAsync(string prompt, CancellationToken cancellationToken = default);
    }
}
