using Newtonsoft.Json;

namespace Tsukumo.StableDiffusion.Models
{
    public class StableDiffusionProcessingTxt2Img
    {
        [JsonProperty("prompt")]
        public string Prompt { get; set; }  // Default: ""
        [JsonProperty("negative_prompt")]
        public string NegativePrompt { get; set; }  // Default: ""
        [JsonProperty("seed", NullValueHandling = NullValueHandling.Ignore)]
        public int? Seed { get; set; }  // Default: -1
        [JsonProperty("steps", NullValueHandling = NullValueHandling.Ignore)]
        public int? Steps { get; set; }  // Default: 50
        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public int? Width { get; set; }  // Default: 512
        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public int? Height { get; set; }  // Default: 512
        [JsonProperty("sampler_name", NullValueHandling = NullValueHandling.Ignore)]
        public string SamplerName { get; set; }  // Default: null
        [JsonProperty("scheduler", NullValueHandling = NullValueHandling.Ignore)]
        public string Scheduler { get; set; }  // Default: null
    }
}
