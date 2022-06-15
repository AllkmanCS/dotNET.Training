using SensorMonitor.BL.Interfaces;
using SensorMonitor.BL.State;
using System;
using System.Timers;

namespace SensorMonitor.BL.MeasuredValueGeneratorsState
{
    public class WorkingValueGeneratorState : SensorState, IValueGenerator
    {
        public override void Handle(Sensor sensor)
        {
            sensor.SensorState = new IdleValueGeneratorState();
        }
        public double GetMeasuredValue(int measurementInterval)
        {
            double value = 0;
            var random = new Random();
            Timer timer = new Timer();
            timer.Interval = measurementInterval;
            timer.Elapsed += (s, e) =>
            {
                value = random.NextDouble() * 1000;
            };
            timer.AutoReset = true;
            timer.Enabled = true;
            return value;
        }
    }
}
