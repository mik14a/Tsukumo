using Tsukumo.ComfyUI.Models;
using Tsukumo.Interfaces;

namespace Tsukumo.ComfyUI.Interfaces
{
    /// <summary>
    /// Defines the interface for ComfyUI prompt execution.
    /// </summary>
    public interface IPromptService : ITxt2ImgService
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
        /// The negative prompt written to <see cref="NegativePromptNodeId"/> on each generation.
        /// </summary>
        string NegativePrompt { get; }
    }
}
