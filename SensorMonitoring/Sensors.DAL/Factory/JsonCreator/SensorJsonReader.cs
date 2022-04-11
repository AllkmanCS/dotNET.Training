using Sensors.DAL.Entities.Abstract;
using Sensors.DAL.Factory.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sensors.DAL.Factory.JsonCreator
{
    public class SensorJsonReader : SensorFactory
    {
        

        public override List<Sensor> GetSensors(string fileName)
        {
            var sensors = new List<Sensor>();
            string jsonString = File.ReadAllText(fileName);

            sensors = JsonSerializer.Deserialize<List<Sensor>>(jsonString);

            return sensors;
        }
    } 
}
