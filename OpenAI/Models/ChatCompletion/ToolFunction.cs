using Newtonsoft.Json;

namespace Tsukumo.OpenAI.Models.ChatCompletion
{
    public class ToolFunction
    {
        /// <summary>
        /// The name of the function to be called.
        /// Must be a-z, A-Z, 0-9, or contain underscores and dashes,
        /// with a maximum length of 64.
        /// </summary>
        /// <value>Required.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A description of what the function does,
        /// used by the model to choose when and how to call the function.
        /// </summary>
        /// <value>Optional.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The parameters the functions accepts, described as a JSON Schema object.
        /// See the guide for examples, and the JSON Schema reference for documentation about the format.
        /// </summary>
        /// <value>Optional. Omitting parameters defines a function with an empty parameter list.</value>
        [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
        //[JsonProperty("parameters")]
        public string Parameters { get; set; }
    }
}
