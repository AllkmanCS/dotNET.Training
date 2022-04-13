using Sensors.DAL.Configurations;
using Sensors.DAL.Factory.Factory;
using System;
using System.Collections.ObjectModel;

namespace Sensors.DAL.Factory
{
    public class XmlSensorConfigurationReader : ISensorConfigurationReader
    {
        public ObservableCollection<SensorConfiguration> Read(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
