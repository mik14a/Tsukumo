using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tsukumo.ComfyUI.Models;

namespace Tsukumo.ComfyUI.Interfaces
{
    /// <summary>
    /// Defines the interface for ComfyUI prompt execution.
    /// </summary>
    public interface IPromptService
    {
        /// <summary>
        /// The API-format workflow this service executes.
        /// </summary>
        Workflow Workflow { get; }

        /// <summary>
        /// Node id whose <c>text</c> input receives the positive prompt.
        /// </summary>
        string PromptNodeId { get; }

        /// <summary>
        /// Node id whose <c>text</c> input receives the negative prompt.
        /// </summary>
        string NegativePromptNodeId { get; }

        /// <summary>
        /// Writes prompts into the injected nodes, queues the workflow, and returns output images.
        /// </summary>
        /// <param name="prompt">The positive prompt written to <see cref="PromptNodeId"/>.</param>
        /// <param name="negativePrompt">The negative prompt written to <see cref="NegativePromptNodeId"/>.</param>
        /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous image generation operation.</returns>
        Task<IReadOnlyList<byte[]>> GenerateAsync(string prompt, string negativePrompt, CancellationToken cancellationToken);
    }
}
