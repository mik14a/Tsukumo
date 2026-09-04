using System.Collections.Generic;

namespace Tsukumo.StableDiffusion.Models
{
    public class Txt2ImgResponse
    {
        public List<string> Images { get; set; }
        public Txt2ImgRequest Parameters { get; set; }
        public string Info { get; set; }
    }
}
