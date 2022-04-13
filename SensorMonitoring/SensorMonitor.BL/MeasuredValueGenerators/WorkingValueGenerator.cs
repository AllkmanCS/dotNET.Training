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
        public int GetMeasuredValue()
        {
            var random = new Random();
            var value = random.Next(0, 100);
            return value;
        }
    }
}
