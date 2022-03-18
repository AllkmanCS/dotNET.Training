using Task1.One.TrainingWebsite.Enums;
using Task1.One.TrainingWebsite.Extensions;

namespace Task1.One.TrainingWebsite.Entities.TrainingMaterial
{
    internal class NetworkResource : EntityBase
    {
        private string _linkToNetworkResource;
        private readonly LinkType _linkType;
        public NetworkResource(string description, string linkToNetworkResource, LinkType linkType) : base(description)
        {
            Description = description;
            if (!string.IsNullOrEmpty(linkToNetworkResource))
            {
                _linkToNetworkResource = linkToNetworkResource;
            }
            else
            {
                throw new NullReferenceException();
            }
            _linkType = linkType;
            this.AssignGuid();
        }
        public override object Clone()
        {
            var networkResourceClone = new NetworkResource(this.Description, this._linkToNetworkResource, this._linkType);
            networkResourceClone.Id = this.Id;
            return networkResourceClone;
        }
        public override string ToString() => $"{Description}";
    }
}
