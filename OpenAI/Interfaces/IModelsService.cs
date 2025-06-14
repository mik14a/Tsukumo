using System.Threading;
using System.Threading.Tasks;
using Tsukumo.OpenAI.Models.Models;

namespace Tsukumo.OpenAI.Interfaces
{
    /// <summary>
    /// Defines the interface for OpenAI models service operations.
    /// </summary>
    public interface IModelsService
    {
        /// <summary>
        /// Lists the currently available models, and provides basic information
        /// about each one such as the owner and availability.
        /// </summary>
        /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous list models operation.</returns>
        Task<ListModelsResponse> ListModels(CancellationToken cancellationToken = default);
    }
}
