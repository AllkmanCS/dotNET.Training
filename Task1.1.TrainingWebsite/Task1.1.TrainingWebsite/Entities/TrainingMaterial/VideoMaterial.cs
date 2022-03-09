using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1._1.TrainingWebsite.Enums;
using Task1._1.TrainingWebsite.Interfaces;

namespace Task1._1.TrainingWebsite.Entities.TrainingMaterial
{
    internal class VideoMaterial : EntityBase, IVersionable
    {
        private string _videoContentUri;
        private string _splashScreenUri;
        private readonly VideoFormat _videoFormat;
        public VideoMaterial(string description, string videoContentURI, string splashScreenURI, VideoFormat videoFormat):base(description)
        {
            Description = description;
            _videoContentUri = videoContentURI;
            _splashScreenUri = splashScreenURI;
            _videoFormat = videoFormat;
        }
        public override object Clone()
        {
            return new VideoMaterial(this.Description, this._videoContentUri, this._splashScreenUri, this._videoFormat);
        }
        public override string ToString()
        {
            return $"{Description}";
        }

        public byte[] ReadVersion()
        {
            throw new NotImplementedException();
        }

        public void SetVersion(byte[] version)
        {
            throw new NotImplementedException();
        }
    }
}
