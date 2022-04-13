using Sensors.DAL.Configurations;
using Sensors.DAL.Factory.Factory;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace Sensors.DAL.Factory
{
    public class JsonSensorConfigurationReader : ISensorConfigurationReader
    {
        //public JsonSensorConfigurationReader()
        //{

        //}
        //public override Sensor AddSensor(Guid id, int measurementInterval)
        //{
        //    throw new NotImplementedException();
        //}

        //public override ObservableCollection<Sensor> GetSensors(string fileName)
        //{
        //    var sensors = new ObservableCollection<Sensor>();
        //    string jsonString = File.ReadAllText(fileName);

        //    sensors = JsonSerializer.Deserialize<ObservableCollection<Sensor>>(jsonString);

        //    return sensors;
        //}

        public ObservableCollection<SensorConfiguration> Read(string filePath)
        {
            var sensors = new ObservableCollection<SensorConfiguration>();
            string jsonString = File.ReadAllText(filePath);
            sensors = JsonSerializer.Deserialize<ObservableCollection<SensorConfiguration>>(jsonString);
            return sensors;
        }
    }
}
