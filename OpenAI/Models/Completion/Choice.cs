using Newtonsoft.Json;

namespace OpenAI.Models.Completion
{
    /// <summary>
    ///  The model generated for the input prompt.
    /// </summary>
    public class Choice
    {
        /// <summary>
        /// The reason the model stopped generating tokens.
        /// This can be 'stop' if the model hit a natural stop point or a provided stop sequence,
        /// 'length' if the maximum number of tokens specified in the request was reached,
        /// or 'content_filter' if content was omitted due to a flag from our content filters.
        /// </summary>
        [JsonProperty("finish_reason")]
        public string FinishReason { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
