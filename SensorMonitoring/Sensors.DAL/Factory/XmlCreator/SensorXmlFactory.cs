using Sensors.DAL.Entities.Abstract;
using Sensors.DAL.Factory.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.DAL.Factory.XmlCreator
{
    public class SensorXmlFactory : SensorFactory
    {
        public override Sensor AddSensor(Guid id, int measurementInterval)
        {
            throw new NotImplementedException();
        }

        public override List<Sensor> GetSensors(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
