using SensorMonitor.BL.Interfaces;
using Sensors.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorMonitor.BL.MeasuredValueGeneratorsState
{
    public class CalibrationValueGeneratorState : IValueGeneratorState
    {
        public double GetMeasuredValue(double value)
        {
            return (int)value ++;
        }
    }
}
