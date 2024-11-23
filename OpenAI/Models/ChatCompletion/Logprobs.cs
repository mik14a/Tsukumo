using System.Collections.Generic;

using Newtonsoft.Json;

namespace OpenAI.Models.ChatCompletion
{
    public class Logprobs
    {
        /// <summary>
        /// Gets or sets a list of message content tokens with log probability information.
        /// </summary>
        [JsonProperty("content")]
        public List<LogprobsContent> Content { get; set; }
    }
}
