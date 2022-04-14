using SensorMonitor.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorMonitor.BL.MeasuredValueGenerators
{
    internal class IdleValueGenerator : IValueGenerator
    {
        public double GetMeasuredValue(double value)
        {
            return 0;
        }
    }
}
