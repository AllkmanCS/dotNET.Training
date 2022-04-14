using Sensors.DAL.Configurations;
using Sensors.DAL.Data;
using Sensors.DAL.Factory.Factory;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace Sensors.DAL.Factory
{
    public class XmlSensorConfigurationReader : ISensorConfigurationReader
    {
        private SensorsSettings _sensorsSettings = new SensorsSettings();
        public XmlSensorConfigurationReader(SensorsSettings sensorsSettings)
        {
            _sensorsSettings = sensorsSettings;
        }
        public XmlSensorConfigurationReader()
        {

        }
        public SensorsSettings Read(string filePath)
        {
            using (var stream = File.OpenRead(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SensorsSettings));
                _sensorsSettings = serializer.Deserialize(stream) as SensorsSettings;
            };
            return _sensorsSettings; 
        }
    }
}
