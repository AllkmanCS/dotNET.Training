using Sensors.DAL.Enums;
using Sensors.DAL.Factory.Factory;

namespace Sensors.DAL.Factory
{
    public static class ConfigurationReaderCreator
    {
        public static ISensorConfigurationReader CreateConfigurationReader(SensorConfigurationFileTypes type )
        {
            if (type == SensorConfigurationFileTypes.Json)
            {
                return new JsonSensorConfigurationReader();
            }
            if (type == SensorConfigurationFileTypes.Xml)
            {
                return new XmlSensorConfigurationReader();
            }
            return null;
        }
    }
}
