using System.Collections.Generic;

namespace Tsukumo.StableDiffusion.Models
{
    public class TextToImageResponse
    {
        public List<string> Images { get; set; }
        public StableDiffusionProcessingTxt2Img Parameters { get; set; }
        public string Info { get; set; }
    }
}
