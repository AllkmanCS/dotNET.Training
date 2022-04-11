using Sensors.DAL.Configurations;
using Sensors.DAL.Entities.Abstract;
using System;

namespace Sensors.DAL.Entities
{
    public class MagneticFieldSensor : Sensor
    {
        public MagneticFieldSensor(Guid id, int measurementInterval)
        {
            Id = id;
            MeasurementInterval = measurementInterval;
        }
    }
}
