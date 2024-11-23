using Newtonsoft.Json;

namespace OpenAI.Models.ChatCompletion
{
    public class ToolChoice
    {
        /// <summary>
        /// The type of the tool. Currently, only function is supported.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The function of the tool. This is a required field.
        /// </summary>
        [JsonProperty("function")]
        public ToolChoiceFunction Function { get; set; }
    }
}
