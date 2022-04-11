using System;


namespace Sensors.DAL.Configurations
{
    public class SensorConfiguration
    {
        public Guid? Id { get; set; }
        public int MeasurementInterval { get; set; }
        public float MeasuredValue { get; set; }
    }
}
