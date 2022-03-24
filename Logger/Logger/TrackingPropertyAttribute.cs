using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TrackingPropertyAttribute : Attribute
    {
        public string Name { get; }

        public TrackingPropertyAttribute(string name)
        {
            Name = name;
        }
        public TrackingPropertyAttribute() { }

    }
}
