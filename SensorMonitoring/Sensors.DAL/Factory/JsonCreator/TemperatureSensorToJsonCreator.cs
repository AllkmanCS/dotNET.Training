using Sensors.DAL.Entities;
using Sensors.DAL.Entities.Abstract;
using Sensors.DAL.Factory.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Sensors.DAL.Factory.JsonCreator
{
    public class TemperatureSensorToJsonCreator : SensorFactory
    {
        private const string _fileName = "..//SensorMonitoring/Sensors.DAL/Data/PrimaryDb.json";

        public override Sensor AddSensor(Guid id, int measurementInterval)
        {
            throw new NotImplementedException();
        }

        //public override void CreateSensor(string fileName, Guid guid, int measurementInterval)
        //{
        //    var sensors = DeserializeJSon();
        //    sensors.Add(new TemperatureSensor
        //    {
        //        Id = guid,
        //        MeasurementInterval = measurementInterval,
        //    });
        //    var options = new JsonSerializerOptions { WriteIndented = true };
        //    string jsonString = JsonSerializer.Serialize(sensors, options);
        //    File.WriteAllText(fileName, jsonString);
        //}

        public override List<Sensor> GetSensors(string fileName)
        {
            throw new NotImplementedException();
        }

        private List<TemperatureSensor> DeserializeJSon()
        {
            return JsonSerializer.Deserialize<List<TemperatureSensor>>(_fileName);
        }
    }
}
