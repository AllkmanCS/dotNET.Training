using SensorMonitor.BL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SensorMonitor.BL.MeasuredValueGeneratorsState
{
    public class IdleValueGeneratorState : IValueGeneratorState
    {
        public double GetMeasuredValue(int measurementInterval)
        {
            while (true)
            {
                var delayTask = Task.Delay(measurementInterval);
                double value = 0;
                return value;
            }
        }
    }
}
