using SensorMonitor.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorMonitor.BL.MeasuredValueGeneratorsState
{
    public class IdleValueGeneratorState : IValueGeneratorState
    {
        public double GetMeasuredValue(double value)
        {
            return 0;
        }
    }
}
