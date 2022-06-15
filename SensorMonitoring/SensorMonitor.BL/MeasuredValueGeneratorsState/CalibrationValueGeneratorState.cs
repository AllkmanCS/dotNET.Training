using SensorMonitor.BL.Interfaces;
using SensorMonitor.BL.State;
using System.Timers;

namespace SensorMonitor.BL.MeasuredValueGeneratorsState
{
    public class CalibrationValueGeneratorState : SensorState, IValueGenerator
    {
        public override void Handle(Sensor sensor)
        {
            sensor.SensorState = new WorkingValueGeneratorState();
        }
        public double GetMeasuredValue(int measurementInterval)
        {
            double value = 0;
            Timer timer = new Timer();
            timer.Interval = measurementInterval;
            timer.Elapsed += (s, e) =>
            {
                value++;
            };
            timer.AutoReset = true;
            timer.Enabled = true;
            return value;
        }
    }
}
