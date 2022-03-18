using Task1.One.TrainingWebsite.Extensions;

namespace Task1.One.TrainingWebsite.Entities.TrainingMaterial
{
    internal class TextMaterial : EntityBase
    {
        private string _text;
        private const int _maxLength = 1000;
        public string Text { get=> _text; set => _text = value; }
        public TextMaterial(string description, string text) : base(description)
        {
            Description = description;
            if (!string.IsNullOrEmpty(text))
            {
                _text = text;
            }
            if (text.Length >= _maxLength)
            {
                _text = text.Substring(0, _maxLength);
            }
            this.AssignGuid();
        }
        public override object Clone()
        {
            var textMaterialClone = new TextMaterial(this.Description, this._text);
            textMaterialClone.Id = this.Id;
            return textMaterialClone;
        }
        public override string ToString() => $"{Description}";
    }
}