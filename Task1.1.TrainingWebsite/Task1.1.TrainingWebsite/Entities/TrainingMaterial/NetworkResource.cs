using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1._1.TrainingWebsite.Enums;

namespace Task1._1.TrainingWebsite.Entities.TrainingMaterial
{
    internal class NetworkResource : EntityBase
    {
        private string _contentUri;
        private readonly LinkType _linkType;
        public NetworkResource(string description, string contentUri, LinkType linkType):base(description)
        {
            Description = description;
            _contentUri = contentUri;
            _linkType = linkType;
        }
        public override object Clone()
        {
            return new NetworkResource(this.Description, this._contentUri, this._linkType);
        }
        public override string ToString()
        {
            return $"{Description}";
        }
    }
}
