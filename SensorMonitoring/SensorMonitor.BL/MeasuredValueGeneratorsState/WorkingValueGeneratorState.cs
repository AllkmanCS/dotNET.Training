using SensorMonitor.BL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SensorMonitor.BL.MeasuredValueGeneratorsState
{
    public class WorkingValueGeneratorState : IValueGeneratorState
    {
        public double GetMeasuredValue(int measurementInterval)
        {
            while (true)
            {
                var delayTask = Task.Delay(measurementInterval);
                var random = new Random();
                double value = random.NextDouble() * 1000;
                return value;
            }
        }
    }
}
