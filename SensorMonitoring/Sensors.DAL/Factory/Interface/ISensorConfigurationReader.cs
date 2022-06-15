using Sensors.DAL.Configurations;

namespace Sensors.DAL.Factory.Factory
{
    public interface ISensorConfigurationReader
    {
        SensorsSettings Read(string filePath);
    }
}
