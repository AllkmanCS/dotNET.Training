using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._1.TrainingWebsite.Entities
{
    internal abstract class EntityBase : ICloneable
    {
        public Guid? Id { get; set; }
        private const int _maxCapacity = 256;
        private string _description;
        public string Description
        {
            get
            {
                var sb = new StringBuilder(_description.Length, _maxCapacity);
                sb.Append(_description);
                return sb.ToString();
            }
            set
            {
                _description = value;
            }
        }
        public EntityBase(string description)
        {
            Description = description;
        }
        public EntityBase()
        {

        }
        public abstract object Clone();
        public override bool Equals(object? obj)
        {
            var other = obj as EntityBase;
            if (obj == null) return false;
            return this.Id == other.Id;
        }
    }
}
