using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tsukumo.OpenAI.Models.Completion;

namespace Tsukumo.OpenAI.Interfaces
{
    /// <summary>
    /// Defines the interface for OpenAI completion service operations.
    /// </summary>
    public interface ICompletionService
    {
        /// <summary>
        /// Creates a completion with the specified request and model ID.
        /// </summary>
        /// <param name="request">The completion request containing the prompt and parameters.</param>
        /// <param name="modelId">The ID of the model to use for completion (optional).</param>
        /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous completion operation.</returns>
        Task<Response> CreateCompletion(Request request,
                                        string modelId = null,
                                        CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a streaming completion with the specified request and model ID.
        /// </summary>
        /// <param name="request">The completion request containing the prompt and parameters.</param>
        /// <param name="modelId">The ID of the model to use for completion (optional).</param>
        /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
        /// <returns>An async enumerable that yields completion responses as they become available.</returns>
        IAsyncEnumerable<Response> CreateCompletionAsStream(Request request,
                                                            string modelId = null,
                                                            CancellationToken cancellationToken = default);
    }
}
