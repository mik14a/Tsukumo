using Newtonsoft.Json;

namespace Tsukumo.OpenAI.Models
{
    public class Response
    {
        public bool Successful => Error == null;
        [JsonProperty("error")]
        public Error Error { get; set; }
    }
}
