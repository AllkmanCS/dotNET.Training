using SensorMonitor.BL.Interfaces;
using Sensors.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorMonitor.BL.MeasuredValueGenerators
{
    internal class CalibrationValueGenerator : IValueGenerator
    {
        public int GetMeasuredValue()
        {
            int value = 0;
            return value ++;
        }
    }
}
