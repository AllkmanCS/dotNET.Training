using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._1.TrainingWebsite.Entities.TrainingMaterial
{
    internal class NetworkResource : EntityBase
    {
        public override object Clone()
        {
            return new NetworkResource();
        }
        public override string ToString()
        {
            return $"{Description}";
        }
    }
}
