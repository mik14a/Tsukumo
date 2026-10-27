using System.Threading;
using System.Threading.Tasks;
using Tsukumo.OpenAI.Models.Embedding;

namespace Tsukumo.OpenAI.Interfaces
{
    /// <summary>
    /// Defines the interface for OpenAI embedding operations.
    /// </summary>
    public interface IEmbeddingService
    {
        /// <summary>
        /// Gets the request URI for the embeddings API endpoint.
        /// </summary>
        string RequestUri { get; }

        /// <summary>
        /// Creates an embedding for <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The embedding request. <see cref="Request.Input"/> is the text or a data URI.</param>
        /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
        /// <returns>The embedding response. <see cref="Tsukumo.OpenAI.Models.Response.Error"/> is set when the call failed.</returns>
        Task<Response> CreateEmbedding(Request request, CancellationToken cancellationToken = default);
    }
}
