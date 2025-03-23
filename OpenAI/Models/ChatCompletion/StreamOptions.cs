using Newtonsoft.Json;

namespace Tsukumo.OpenAI.Models.ChatCompletion
{
    /// <summary>
    /// Options for streaming response.
    /// </summary>
    public class StreamOptions
    {
        /// <summary>
        /// If set, an additional chunk will be streamed before the data: [DONE] message.
        /// The usage field on this chunk shows the token usage statistics for the entire request,
        /// and the choices field will always be an empty array.
        /// All other chunks will also include a usage field, but with a null value.
        /// NOTE: If the stream is interrupted, you may not receive the final usage chunk
        /// which contains the total token usage for the request.
        /// </summary>
        /// <value>Optional.</value>
        [JsonProperty("include_usage")]
        public bool? IncludeUsage { get; set; }
    }
}
