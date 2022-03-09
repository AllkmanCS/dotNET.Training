using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public TextMaterial()
        {

        }
        public TextMaterial(string text)
        {
            Text = text;
        }
        public TextMaterial(string text, string description)
        {
            Text = text;
            Description = description;
        }
        public override object Clone()
        {
            return new TextMaterial(_text);
        }
        public override string ToString()
        {
            return $"{Description}";
        }
    }
}