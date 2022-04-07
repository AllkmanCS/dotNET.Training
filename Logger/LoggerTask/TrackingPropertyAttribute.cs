namespace LoggerTask
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TrackingPropertyAttribute : Attribute
    {
        public string Name { get; }

        public TrackingPropertyAttribute(string name)
        {
            Name = name;
        }
        public TrackingPropertyAttribute() { }

    }
}
