using Sensors.DAL.Configurations;
using Sensors.DAL.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sensors.DAL.Factory.Factory
{
    public interface ISensorConfigurationReader
    {
        SensorsSettings Read(string filePath);
    }
}
