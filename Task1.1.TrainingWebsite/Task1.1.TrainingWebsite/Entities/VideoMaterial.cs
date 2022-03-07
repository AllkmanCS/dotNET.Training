using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1._1.TrainingWebsite.Enums;

namespace Task1._1.TrainingWebsite.Entities
{
    internal class VideoMaterial : IEntity
    {
        public Guid? Id { get; set; }
        public string? Description { get; set; }
        public string VideoContentURI { get; set; }
        public string SplashScreenURI { get; set; }
        public VideoFormat VideoFormat { get; set; }
    }
}
