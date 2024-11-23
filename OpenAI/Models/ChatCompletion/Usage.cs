using Newtonsoft.Json;

namespace OpenAI.Models.ChatCompletion
{
    /// <summary>
    /// Usage statistics
    /// </summary>
    public class Usage
    {
        /// <summary>
        /// Number of tokens in the generated completion.
        /// </summary>
        [JsonProperty("completion_tokens")]
        public int CompletionTokens { get; set; }

        /// <summary>
        /// Number of tokens in the prompt.
        /// </summary>
        [JsonProperty("prompt_tokens")]
        public int PromptTokens { get; set; }

        /// <summary>
        /// Total number of tokens used in the request (prompt + completion).
        /// </summary>
        [JsonProperty("total_tokens")]
        public int TotalTokens { get; set; }
    }
}
