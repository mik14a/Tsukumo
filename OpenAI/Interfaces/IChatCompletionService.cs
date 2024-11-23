using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenAI.Models.ChatCompletion;

namespace OpenAI.Interfaces
{
    public interface IChatCompletionService
    {
        public string RequestUri { get; }

        Task<Response> CreateChatCompletion(Request request,
                                            string modelId = null,
                                            CancellationToken cancellationToken = default);

        IAsyncEnumerable<Response> CreateChatCompletionAsStream(Request request,
                                                                string modelId = null,
                                                                CancellationToken cancellationToken = default);
    }
}
