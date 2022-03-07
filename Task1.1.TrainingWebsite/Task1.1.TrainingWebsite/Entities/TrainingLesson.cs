using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1._1.TrainingWebsite.Interfaces;

namespace Task1._1.TrainingWebsite.Entities
{
    internal class TrainingLesson : IEntity, IVersionable
    {
        public Guid? Id { get; set; }
        public string? Description { get; set; }
        public byte[] Version { get; set; }

        public Type GetTrainingType()
        {
            if (true)
            {

            }
            return typeof(TrainingLesson);
        }
        public override string ToString()
        {
            return $"{Description}";
        }
    }
}
