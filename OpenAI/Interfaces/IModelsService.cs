using System.Threading;
using System.Threading.Tasks;
using Tsukumo.OpenAI.Models.Models;

namespace Tsukumo.OpenAI.Interfaces
{
    public interface IModelsService
    {
        /// <summary>
        /// Lists the currently available models, and provides basic information
        /// about each one such as the owner and availability.
        /// </summary>
        Task<ListModelsResponse> ListModels(CancellationToken cancellationToken = default);
    }
}
