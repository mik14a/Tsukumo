using Newtonsoft.Json;

namespace Tsukumo.OpenAI.Models.Embedding
{
    /// <summary>One embedding in an embeddings response.</summary>
    public class EmbeddingData
    {
        /// <summary>The object type, which is always <c>embedding</c>.</summary>
        [JsonProperty("object")]
        public string Object { get; set; } = "embedding";

        /// <summary>The embedding vector.</summary>
        [JsonProperty("embedding")]
        public float[] Embedding { get; set; }

        /// <summary>The index of this embedding in the request.</summary>
        [JsonProperty("index")]
        public int Index { get; set; }
    }
}
