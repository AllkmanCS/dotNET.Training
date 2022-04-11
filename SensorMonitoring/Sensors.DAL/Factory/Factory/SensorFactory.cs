using Sensors.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Sensors.DAL.Factory.Factory
{
    public abstract class SensorFactory
    {
        private List<Sensor> _sensors;
        public List<Sensor> Sensors { get => _sensors; }
        public abstract List<Sensor> GetSensors(string fileName);
        public abstract Sensor AddSensor(Guid id, int measurementInterval);
    }
}
