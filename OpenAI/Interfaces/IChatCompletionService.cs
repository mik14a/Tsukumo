using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tsukumo.OpenAI.Models.ChatCompletion;

namespace Tsukumo.OpenAI.Interfaces
{
    /// <summary>
    /// Defines the interface for OpenAI chat completion service operations.
    /// </summary>
    public interface IChatCompletionService
    {
        /// <summary>
        /// Gets the request URI for the chat completion API endpoint.
        /// </summary>
        string RequestUri { get; }

        /// <summary>
        /// Creates a chat completion with the specified request and timeout.
        /// </summary>
        /// <param name="request">The chat completion request containing messages and parameters.</param>
        /// <param name="timeout">The timeout duration for the request.</param>
        /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous chat completion operation.</returns>
        Task<Response> CreateChatCompletion(Request request,
                                            TimeSpan timeout,
                                            CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a streaming chat completion with the specified request.
        /// </summary>
        /// <param name="request">The chat completion request containing messages and parameters.</param>
        /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
        /// <returns>An async enumerable that yields chat completion responses as they become available.</returns>
        IAsyncEnumerable<Response> CreateChatCompletionAsStream(Request request,
                                                                CancellationToken cancellationToken = default);
    }
}
