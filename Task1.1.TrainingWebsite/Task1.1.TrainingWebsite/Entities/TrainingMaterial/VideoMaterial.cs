using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1._1.TrainingWebsite.Enums;

namespace Task1._1.TrainingWebsite.Entities.TrainingMaterial
{
    internal class VideoMaterial : EntityBase
    {
        public string VideoContentURI { get; set; }
        public string SplashScreenURI { get; set; }
        private readonly VideoFormat _videoFormat;

        public VideoMaterial()
        {

        }
        public VideoMaterial(string videoContentURI, string splashScreenURI, VideoFormat videoFormat)
        {
            VideoContentURI = videoContentURI;
            SplashScreenURI = splashScreenURI;
            _videoFormat = videoFormat;
        }
        public override object Clone()
        {
            return new VideoMaterial();
        }
        public override string ToString()
        {
            return $"{Description}";
        }
    }
}
