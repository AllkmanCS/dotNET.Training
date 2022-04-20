using SensorMonitor.BL.Interfaces;
using System;
using System.ComponentModel;

namespace SensorMonitor.BL.Observer
{
    public class Engineer : IObserver
    {
        public void Update(Sensor sensor)
        {
            sensor.PropertyChanged += Sensor_PropertyChanged;
        }

        private void Sensor_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine($"Measured Value has changed to.");
        }
    }
}
