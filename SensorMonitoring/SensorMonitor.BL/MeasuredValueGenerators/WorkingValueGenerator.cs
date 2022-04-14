using Microsoft.Extensions.Configuration;
using SensorMonitor.BL.Interfaces;
using Sensors.DAL.Configurations;
using Sensors.DAL.Enums;
using Sensors.DAL.Factory.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorMonitor.BL.MeasuredValueGenerators
{
    internal class WorkingValueGenerator : IValueGenerator
    {
        public double GetMeasuredValue(double value)
        {
            var random = new Random();
            value = random.NextDouble()*1000;
            return value;
        }
    }
}
