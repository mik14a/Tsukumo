using Newtonsoft.Json;

namespace OpenAI.Models.ChatCompletion
{
    /// <summary>
    /// The function of the tool.
    /// </summary>
    public class ToolChoiceFunction
    {
        /// <summary>
        /// The name of the function to call.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
