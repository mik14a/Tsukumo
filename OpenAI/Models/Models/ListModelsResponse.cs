using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tsukumo.OpenAI.Models.Models
{
    /// <summary>
    /// Response containing a list of available models.
    /// </summary>
    public class ListModelsResponse
    {
        /// <summary>
        /// The object type, which is always "list".
        /// </summary>
        [JsonProperty("object")]
        public string Object { get; set; } = "list";

        /// <summary>
        /// List of available models.
        /// </summary>
        [JsonProperty("data")]
        public List<Model> Data { get; set; }
    }
}
