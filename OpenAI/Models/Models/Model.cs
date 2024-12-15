using Newtonsoft.Json;

namespace Tsukumo.OpenAI.Models.Models
{
    /// <summary>
    /// Represents an OpenAI model that can be used with the API.
    /// </summary>
    public class Model
    {
        /// <summary>
        /// The model identifier, which can be referenced in the API endpoints.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The Unix timestamp (in seconds) when the model was created.
        /// </summary>
        [JsonProperty("created")]
        public int Created { get; set; }

        /// <summary>
        /// The object type, which is always "model".
        /// </summary>
        [JsonProperty("object")]
        public string Object { get; set; } = "model";

        /// <summary>
        /// The organization that owns the model.
        /// </summary>
        [JsonProperty("owned_by")]
        public string OwnedBy { get; set; }
    }
}
