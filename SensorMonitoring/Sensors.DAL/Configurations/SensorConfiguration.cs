using Sensors.DAL.Enums;
using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Sensors.DAL.Configurations
{
    public class SensorConfiguration
    {
        [JsonIgnore]
        [XmlIgnore]
        public Guid Id { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SensorTypes SensorType { get; set; }
        public int MeasurementInterval { get; set; }
        
    }
}