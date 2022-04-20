using SensorMonitor.BL.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SensorMonitor.BL.MeasuredValueGeneratorsState
{
    public class IdleValueGeneratorState : IValueGeneratorState
    {
        public double GetMeasuredValue(TimeSpan timeSpan)
        {
            while (true)
            {
                var delayTask = Task.Delay(timeSpan.Milliseconds);
                double value = 0;
                return value;
            }
        }
    }
}
