using Newtonsoft.Json;

namespace Tsukumo.OpenAI.Models.Embedding
{
    /// <summary>
    /// Creates an embedding vector for the given input.
    /// </summary>
    /// <remarks>https://platform.openai.com/docs/api-reference/embeddings/create</remarks>
    public class Request
    {
        /// <summary>ID of the model to use.</summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>The text to embed, or a <c>data:</c> URI when <see cref="InputModalities"/> names an image.</summary>
        [JsonProperty("input")]
        public string Input { get; set; }

        /// <summary>The format to return the embeddings in. <c>float</c> or <c>base64</c>.</summary>
        [JsonProperty("encoding_format")]
        public string EncodingFormat { get; set; }

        /// <summary>Modalities of <see cref="Input"/>, such as <c>image</c>. Omitted when null.</summary>
        [JsonProperty("inputModalities")]
        public string[] InputModalities { get; set; }
    }
}
