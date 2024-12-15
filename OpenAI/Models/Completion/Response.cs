using Newtonsoft.Json;

namespace Tsukumo.OpenAI.Models.Completion
{
    /// <summary>
    /// The completion object
    /// Represents a completion response from the API.
    /// Note: both the streamed and non-streamed response objects share the same shape (unlike the chat endpoint).
    /// </summary>
    /// <remarks>https://platform.openai.com/docs/api-reference/completions/object</remarks>
    public class Response : Tsukumo.OpenAI.Models.Response
    {
        /// <summary>
        /// The model used for completion.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// The list of completion choices the model generated for the input prompt.
        /// </summary>
        [JsonProperty("choices")]
        public Choice[] Choices { get; set; }

        /// <summary>
        /// The Unix timestamp (in seconds) of when the completion was created.
        /// </summary>
        [JsonProperty("created")]
        public int Created { get; set; }

        /// <summary>
        /// This fingerprint represents the backend configuration that the model runs with.
        /// </summary>
        /// <remarks>
        /// Can be used in conjunction with the seed request parameter to understand when backend changes have been made that might impact determinism.
        /// </remarks>
        [JsonProperty("system_fingerprint")]
        public string SystemFingerprint { get; set; }

        /// <summary>
        /// The object type, which is always "text_completion"
        /// </summary>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <summary>
        /// Usage statistics for the completion request.
        /// </summary>
        [JsonProperty("usage")]
        public Usage Usage { get; set; }
    }
}
