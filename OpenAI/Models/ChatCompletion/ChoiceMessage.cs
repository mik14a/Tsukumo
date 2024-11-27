using System.Collections.Generic;

using Newtonsoft.Json;

namespace Tsukumo.OpenAI.Models.ChatCompletion
{
    public class ChoiceMessage
    {
        /// <summary>
        /// The role of the author of this message.
        /// </summary>
        [JsonProperty("role")]
        public string Role { get; set; }

        /// <summary>
        /// The contents of the message.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// The tool calls generated by the model, such as function calls.
        /// </summary>
        [JsonProperty("tool_calls")]
        public List<ToolCall> ToolCalls { get; set; }
    }
}
