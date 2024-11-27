using Newtonsoft.Json;

namespace Tsukumo.OpenAI.Models.ChatCompletion
{
    public class Tool
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
        public ToolFunction Function { get; set; }
    }
}
