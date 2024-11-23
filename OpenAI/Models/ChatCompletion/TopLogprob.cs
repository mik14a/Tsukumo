using Newtonsoft.Json;

namespace OpenAI.Models.ChatCompletion
{
    /// <summary>
    /// List of the most likely tokens and their log probability, at this token position. In rare cases, there may be fewer than the number of requested top_logprobs returned.
    /// </summary>
    public class TopLogprob
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
        [JsonProperty("bytes", NullValueHandling = NullValueHandling.Ignore)]
        public int[] Bytes { get; set; }
    }
}
