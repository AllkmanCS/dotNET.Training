using Sensors.DAL.Configurations;
using Sensors.DAL.Data;
using Sensors.DAL.Factory.Factory;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace Sensors.DAL.Factory
{
    public class JsonSensorConfigurationReader : ISensorConfigurationReader
    {
        private SensorsSettings _sensorsSettings = new SensorsSettings();
        public JsonSensorConfigurationReader(SensorsSettings sensorsSettings)
        {
            _sensorsSettings = sensorsSettings;
        }
        public JsonSensorConfigurationReader()
        {

        }
        public SensorsSettings Read(string filePath)
        {
     
            string jsonString = File.ReadAllText(filePath);
                var list = JsonSerializer.Deserialize<ObservableCollection<SensorConfiguration>>(jsonString)!;
            _sensorsSettings = new SensorsSettings(list);
            return _sensorsSettings;
        }
    }
}
