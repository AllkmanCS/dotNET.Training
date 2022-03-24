using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class TrackingEntityAttribute : Attribute { }
}
