namespace Task1.One.TrainingWebsite.Entities
{
    internal abstract class EntityBase : ICloneable
    {
        public Guid? Id { get; set; }
        private const int _maxLength = 256;
        private string _description;
        public string Description { get => _description; set => _description = value; }
        public EntityBase(string description)
        {
            _description = description;
            if (description.Length >= _maxLength)
            {
                _description = description.Substring(0, _maxLength);
            }
        }
        public abstract object Clone();
        public abstract string ToString();
        public override bool Equals(object? obj)
        {
            var other = obj as EntityBase;
            if (obj == null)
            {
                return false;
            }
            return this.Id == other.Id;
        }
    }
}
