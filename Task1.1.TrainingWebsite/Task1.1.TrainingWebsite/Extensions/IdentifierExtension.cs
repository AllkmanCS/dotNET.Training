using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._1.TrainingWebsite.Extensions
{
    internal static class IdentifierExtension
    {
        public static bool AssignGuid(this Guid guid)
        {
            //TODO if() ...
            return guid == Guid.NewGuid();
        }
    }
}
