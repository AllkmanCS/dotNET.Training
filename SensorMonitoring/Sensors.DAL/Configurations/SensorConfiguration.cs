using Sensors.DAL.Enums;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Sensors.DAL.Configurations
{
    public class SensorConfiguration
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SensorTypes SensorType { get; set; }
        public int MeasurementInterval { get; set; }
        public SensorConfiguration()
        {
            Id = Guid.NewGuid();
        }
    }
}
