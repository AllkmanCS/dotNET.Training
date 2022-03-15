using Task1.One.TrainingWebsite.Enums;
using Task1.One.TrainingWebsite.Extensions;
using Task1.One.TrainingWebsite.Interfaces;

namespace Task1.One.TrainingWebsite.Entities.TrainingMaterial
{
    internal class VideoMaterial : EntityBase, IVersionable
    {
        private string _videoContentUri;
        private string _splashScreenUri;
        private readonly VideoFormat _videoFormat;
        private ulong _version;
        public byte[] ReadVersion(ulong version) => BitConverter.GetBytes(_version);
        public ulong SetVersion(ulong version) => _version = version;
        public VideoMaterial(
            string description,
            string videoContentURI,
            string splashScreenURI,
            VideoFormat videoFormat,
            ulong version
            ) : base(description)
        {
            Description = description;
            if (!string.IsNullOrEmpty(videoContentURI))
                _videoContentUri = videoContentURI;

            else throw new NullReferenceException();

            _splashScreenUri = splashScreenURI;
            _videoFormat = videoFormat;
            _version = version;
            this.AssignGuid();
        }
        public override object Clone()
        {
            var videoMaterialClone = new VideoMaterial(
                this.Description,
                this._videoContentUri,
                this._splashScreenUri,
                this._videoFormat,
                this._version);

            videoMaterialClone.Id = null;
            videoMaterialClone.AssignGuid();
            return videoMaterialClone;
        }
        public override string ToString() => $"{Description}";
    }
}
