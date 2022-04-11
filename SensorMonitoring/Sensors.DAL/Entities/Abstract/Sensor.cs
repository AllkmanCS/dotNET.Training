using Sensors.DAL.Enums;
using System;
using System.Text.Json.Serialization;

namespace Sensors.DAL.Entities.Abstract
{
    public abstract class Sensor
    {
        public Guid? Id { get; set; }
        [JsonIgnore]
        public float MeasuredValue { get; set; }
        public int MeasurementInterval { get; set; }
        public Sensor()
        {

        }
    }
}
