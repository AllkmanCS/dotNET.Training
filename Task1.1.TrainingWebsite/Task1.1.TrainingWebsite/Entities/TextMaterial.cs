using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._1.TrainingWebsite.Entities
{
    internal class TextMaterial :IEntity
    {
        [MaxLength(1000)]
        public int MyProperty { get; set; }
        public Guid? Id { get; set; }
        public string? Description { get; set; }
    }
}
