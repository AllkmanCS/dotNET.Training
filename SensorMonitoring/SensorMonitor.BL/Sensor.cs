using SensorMonitor.BL.Interfaces;
using SensorMonitor.BL.MeasuredValueGeneratorsState;
using Sensors.DAL.Configurations;
using Sensors.DAL.Enums;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SensorMonitor.BL
{
    public class Sensor : ISensor
    {
        //setting default sesnor state
        private SensorModes _sensorMode = SensorModes.Idle;
        public SensorModes SensorMode { get { return _sensorMode; } set { _sensorMode = value; } }
        private IValueGeneratorState _generator;
        private Guid _id = Guid.NewGuid();
        public Guid Id { get { return _id; } set { _id = value; } }
        private int _measurementInterval;
        public int MeasurementInterval { get { return _measurementInterval; } set { _measurementInterval = value; } }
        private SensorTypes _sensorType;
        public SensorTypes SensorType { get { return _sensorType; } set { _sensorType = value; } }
        public event PropertyChangedEventHandler? PropertyChanged;
        private int _measuredValue;
        public int MeasuredValue
        {
            get => _measuredValue;
            set
            {
                _measuredValue = value;
                OnPropertyChanged();
            }
        }

        public Sensor(SensorConfiguration configuration)
        {
            Id = Guid.NewGuid();
            MeasurementInterval = configuration.MeasurementInterval;
            SensorType = configuration.SensorType;
            SensorMode = _sensorMode;
        }
        public void SwitchMode(SensorModes sensorMode)
        {
            switch (sensorMode)
            {
                case SensorModes.Idle:
                    _sensorMode = SensorModes.Calibration;
                    _generator = new CalibrationValueGeneratorState();
                    _generator.GetMeasuredValue(_measuredValue);
                    break;
                case SensorModes.Calibration:
                    _sensorMode = SensorModes.Working;
                    _generator = new WorkingValueGeneratorState();
                    _generator.GetMeasuredValue(_measuredValue);
                    break;
                case SensorModes.Working:
                    _sensorMode = SensorModes.Idle;
                    _generator = new IdleValueGeneratorState();
                    _generator.GetMeasuredValue(_measuredValue);
                    break;
                default:
                    break;
            }
        }
        protected virtual void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MeasuredValue)));
        }

        public void Attach(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Detach(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}