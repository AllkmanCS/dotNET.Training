using Sensors.DAL.Configurations;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sensors.DAL.Factory.Factory
{
    public interface ISensorConfigurationReader
    {
        ObservableCollection<SensorConfiguration> Read(string filePath);
    }
}
