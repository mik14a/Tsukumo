using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tsukumo.OpenAI.Models.Embedding
{
    /// <summary>The response from the embeddings API.</summary>
    public class Response : Tsukumo.OpenAI.Models.Response
    {
        /// <summary>The object type, which is always <c>list</c>.</summary>
        [JsonProperty("object")]
        public string Object { get; set; } = "list";

        /// <summary>The embeddings, one per input.</summary>
        [JsonProperty("data")]
        public List<EmbeddingData> Data { get; set; }

        /// <summary>The model that produced the embeddings.</summary>
        [JsonProperty("model")]
        public string Model { get; set; }
    }
}
