using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._1.TrainingWebsite.Entities
{
    public interface IEntity
    {
        public Guid? Id { get; set; }
        [MaxLength(256)]
        public string? Description { get; set; }
    }
}
