using Newtonsoft.Json;

namespace OpenAI.Models
{
    public class Response
    {
        public bool Successful => Error == null;
        [JsonProperty("error")]
        public Error Error { get; set; }
    }
}
