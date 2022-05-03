using SensorMonitor.BL.Interfaces;
using SensorMonitor.BL.MeasuredValueGeneratorsState;
using SensorMonitor.BL.State;
using Sensors.DAL.Configurations;
using Sensors.DAL.Enums;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SensorMonitor.BL
{
    public class Sensor : ISensor, INotifyPropertyChanged
    {
        private SensorState _state;
        public SensorState SensorState
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine("State: " + _state.GetType().Name);
            }
        }
        private Sensor Sensorss { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        //setting default sesnor state
        private SensorModes _sensorMode = SensorModes.Idle;
        public SensorModes SensorMode 
        { 
            get 
            { 
                return _sensorMode; 
            } 
            set 
            { 
                _sensorMode = value;
                NotifyPropertyChanged(_sensorMode);
            } 
        }

        private void NotifyPropertyChanged(SensorModes sensorMode)
        {
        }

        private IValueGeneratorState _generator;
        private Guid _id = Guid.NewGuid();
        public Guid Id { get { return _id; } set { _id = value; } }
        private int _measurementInterval;
        public int MeasurementInterval { get { return _measurementInterval; } set { _measurementInterval = value; } }
        private SensorTypes _sensorType;
        public SensorTypes SensorType { get { return _sensorType; } set { _sensorType = value; } }
        private double _measuredValue;
        public double MeasuredValue
        {
            get => _measuredValue;
            set
            {
                _measuredValue = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<IObserver> _observers = new ObservableCollection<IObserver>();

        public Sensor(SensorConfiguration configuration, SensorState state)
        {
            Id = Guid.NewGuid();
            MeasurementInterval = configuration.MeasurementInterval;
            SensorType = configuration.SensorType;
            SensorMode = _sensorMode;
            _state = state;
        }
        public async Task SwitchMode(SensorModes sensorMode)
        {
            switch (sensorMode)
            {
                case SensorModes.Idle:
                    _sensorMode = SensorModes.Calibration;
                    _generator = new CalibrationValueGeneratorState(Sensorss);
                    _measuredValue = _generator.GetMeasuredValue(_measurementInterval);
                    break;
                case SensorModes.Calibration:
                    _sensorMode = SensorModes.Working;
                    _generator = new WorkingValueGeneratorState();
                    _measuredValue = _generator.GetMeasuredValue(_measurementInterval);
                    break;
                case SensorModes.Working:
                    _sensorMode = SensorModes.Idle;
                    _generator = new IdleValueGeneratorState();
                    _measuredValue = _generator.GetMeasuredValue(_measurementInterval);
                    break;
                default:
                    break;
            }
        }

        public void Request()
        {
            _state.Handle(this);
        }
        protected virtual void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MeasuredValue)));
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            if (observer != null)
            {
                _observers.Remove(observer);
            }
        }
        public void Notify()
        {
            foreach (var item in _observers)
            {
                item.Update(this);
            }
        }
    }
}