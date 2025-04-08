using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tsukumo.OpenAI.Models.ChatCompletion;

namespace Tsukumo.OpenAI.Interfaces
{
    public interface IChatCompletionService
    {
        public string RequestUri { get; }

        Task<Response> CreateChatCompletion(Request request,
                                            TimeSpan timeout,
                                            CancellationToken cancellationToken = default);

        IAsyncEnumerable<Response> CreateChatCompletionAsStream(Request request,
                                                                CancellationToken cancellationToken = default);
    }
}
