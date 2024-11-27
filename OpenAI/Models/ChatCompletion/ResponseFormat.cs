using Newtonsoft.Json;

namespace Tsukumo.OpenAI.Models.ChatCompletion
{
    /// <summary>
    /// Important: when using JSON mode,
    /// you must also instruct the model to produce JSON yourself via a system or user message.
    /// Without this, the model may generate an unending stream of whitespace until the generation reaches the token limit,
    /// resulting in a long-running and seemingly "stuck" request.
    /// Also note that the message content may be partially cut off if finish_reason="length",
    /// which indicates the generation exceeded max_tokens or the conversation exceeded the max context length.
    /// </summary>
    public class ResponseFormat
    {
        /// <summary>
        /// Static class defining the types of response formats.
        /// </summary>
        public static class Types
        {
            /// <summary>
            /// String indicating the text format.
            /// </summary>
            public static string Text = "text";
            /// <summary>
            /// String indicating the JSON object format.
            /// </summary>
            public static string JsonObject = "json_object";
        }

        /// <summary>
        /// Type of the response format.
        /// </summary>
        /// <value>Optional. Defaults to "text". Must be one of "text" or "json_object".</value>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}
