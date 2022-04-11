using Sensors.DAL.Entities;
using Sensors.DAL.Entities.Abstract;
using Sensors.DAL.Factory.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SensorMonitoring.DAL.Factory.XmlCreator
{
    public class TemperatureSensorToXmlCreator : SensorFactory
    {
        private const string _fileName = "..//SensorMonitoring/Sensors.DAL/Data/SecondaryDb.xml";

        public override Sensor AddSensor(Guid id, int measurementInterval)
        {
            throw new NotImplementedException();
        }

        //public override void CreateSensor(string fileName, Guid guid, int measurementInterval)
        //{
        //    var sensors = DeserializeXml();
        //    sensors.Add(new TemperatureSensor
        //    {
        //        Id = guid,
        //        MeasurementInterval = measurementInterval,
        //    });
        //    var serializer = new XmlSerializer(typeof(List<TemperatureSensor>));
        //    using (var stream = new StreamWriter(_fileName))
        //    {
        //        serializer.Serialize(stream, sensors);
        //    }
        //}

        public override List<Sensor> GetSensors(string fileName)
        {
            throw new NotImplementedException();
        }

        private List<TemperatureSensor> DeserializeXml()
        {
            var deserializer = new XmlSerializer(typeof(List<TemperatureSensor>));
            var sensors = new List<TemperatureSensor>();
            using (var reader = new StreamReader(_fileName))
            {
                sensors = deserializer.Deserialize(reader) as List<TemperatureSensor>;
            }
            return sensors;
        }
    }
}
