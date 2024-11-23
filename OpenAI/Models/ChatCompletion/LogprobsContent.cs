using System.Collections.Generic;

using Newtonsoft.Json;

namespace OpenAI.Models.ChatCompletion
{
    /// <summary>
    /// Represents a token with associated log probability information.
    /// </summary>
    public class LogprobsContent
    {
        /// <summary>
        /// The token string.
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// The log probability of this token.
        /// </summary>
        [JsonProperty("logprob")]
        public double Logprob { get; set; }

        /// <summary>
        /// A list of integers representing the UTF-8 bytes of the token.
        /// </summary>
        [JsonProperty("bytes")]
        public int[] Bytes { get; set; }

        /// <summary>
        /// List of most likely tokens and their log probabilities at this position.
        /// </summary>
        [JsonProperty("top_logprobs")]
        public Dictionary<string, double>[] TopLogprobs { get; set; }
    }
}
