using Newtonsoft.Json;

namespace OpenAI.Models
{
    /// <summary>
    /// Represents an error that can occur during a chat completion.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// The error message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// The type of the error.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The parameter that caused the error.
        /// </summary>
        [JsonProperty("param")]
        public string Param { get; set; }

        /// <summary>
        /// The error code.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
