using SensorMonitor.BL.Interfaces;
using SensorMonitor.BL.State;

namespace SensorMonitor.BL.MeasuredValueGeneratorsState
{
    public class IdleValueGeneratorState : SensorState, IValueGenerator
    {
        public override void Handle(Sensor sensor)
        {
            sensor.SensorState = new CalibrationValueGeneratorState();
        }
        public double GetMeasuredValue(int measurementInterval)
        {
            double value = 0;
            return value;
        }
    }
}
