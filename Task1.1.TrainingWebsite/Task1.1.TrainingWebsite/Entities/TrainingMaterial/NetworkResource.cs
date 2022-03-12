﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1._1.TrainingWebsite.Enums;

namespace Task1._1.TrainingWebsite.Entities.TrainingMaterial
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
            _linkType = linkType;
        }
        public override object Clone()
        {
            return new NetworkResource(this.Description, this._linkToNetworkResource, this._linkType);
        }
        public override string ToString()
        {
            return $"{Description}";
        }
    }
}
