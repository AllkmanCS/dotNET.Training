using Sensors.DAL.Configurations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sensors.DAL.Configurations
{
    [XmlRoot("sensors")]
    public class SensorsSettings
    {
        [XmlElement("sensorConfiguration", Type = typeof(SensorConfiguration))]
        public ObservableCollection<SensorConfiguration> Sensors { get; set; } = new ObservableCollection<SensorConfiguration>();
        public SensorsSettings(ObservableCollection<SensorConfiguration> sensors)
        {
            Sensors = sensors;
        }
        public SensorsSettings() { }
    }
}
