using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1._1.TrainingWebsite.Entities;

namespace Task1._1.TrainingWebsite.Extensions
{
    internal static class IdentifierExtension
    {
        internal static void AssignGuid(this EntityBase entity)
        {
            Guid guid = Guid.NewGuid();
            if (entity.Id == null) entity.Id = guid;
            else throw new InvalidOperationException();

        }
    }
}
