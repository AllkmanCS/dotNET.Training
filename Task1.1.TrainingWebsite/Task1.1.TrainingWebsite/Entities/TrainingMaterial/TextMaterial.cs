using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1._1.TrainingWebsite.Extensions;

namespace Task1._1.TrainingWebsite.Entities.TrainingMaterial
{
    internal class TextMaterial : EntityBase
    {
        private string _text;
        private const int _maxCapacity = 1000;
        public string Text
        {
            get
            {
                var sb = new StringBuilder(_text.Length, _maxCapacity);
                sb.Append(_text);
                return sb.ToString();
            }
            set
            {
                _text = value;
            }
        }
        public TextMaterial(string description, string text): base(description)
        {
            Description = description;
            if (!string.IsNullOrEmpty(text))
            {
                Text = text;
            }
            this.AssignGuid();
        }
        public override object Clone()
        {
            var textMaterialClone = new TextMaterial(this.Description, this._text);
            textMaterialClone.Id = null;
            textMaterialClone.AssignGuid();
            return textMaterialClone;
        }
        public override string ToString()
        {
            return $"{Description}";
        }
    }
}