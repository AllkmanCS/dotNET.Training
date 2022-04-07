namespace LoggerTask.TestClasses
{
    [TrackingEntity]
    public class TestOne
    {
        [TrackingProperty]
        public int Id { get; set; }
        [TrackingProperty]
        public string PropOne { get; set; }
        public string PropTwo { get; set; }
        public int FieldOne;
        [TrackingProperty]
        public int FieldTwo;
        public TestOne(int id, string propOne, string propTwo, int fieldOne, int fieldTwo)
        {
            Id = id;
            PropOne = propOne;
            PropTwo = propTwo;
            FieldOne = fieldOne;
            FieldTwo = fieldTwo;
        }
    }
}
