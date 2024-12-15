using System.Collections.Generic;

using Newtonsoft.Json;

namespace Tsukumo.OpenAI.Models.ChatCompletion
{
    /// <summary>
    /// Represents a streamed chunk of a chat completion response returned by model,
    /// based on the provided input.
    /// </summary>
    /// <remarks>https://platform.openai.com/docs/api-reference/chat/object</remarks>
    public class Response : Tsukumo.OpenAI.Models.Response
    {
        /// <summary>
        /// A unique identifier for the chat completion.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// A list of chat completion choices. Can be more than one if n is greater than 1.
        /// </summary>
        [JsonProperty("choices")]
        public List<Choice> Choices { get; set; }

        /// <summary>
        /// The Unix timestamp (in seconds) of when the chat completion was created.
        /// </summary>
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public int? Created { get; set; }

        /// <summary>
        /// The model used for the chat completion.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// This fingerprint represents the backend configuration that the model runs with.
        /// Can be used in conjunction with the seed request parameter to understand when backend changes have been made that might impact determinism.
        /// </summary>
        [JsonProperty("system_fingerprint")]
        public string SystemFingerprint { get; set; }

        /// <summary>
        /// The object type, which is always chat.completion.
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
