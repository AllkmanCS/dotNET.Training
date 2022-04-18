using SensorMonitor.BL.Interfaces;
using SensorMonitor.BL.MeasuredValueGenerators;
using Sensors.DAL.Configurations;
using Sensors.DAL.Enums;
using System;

namespace SensorMonitor.BL
{
    public class Sensor
    {

        //setting default sesnor mode
        private SensorModes _sensorMode = SensorModes.Idle;
        public SensorModes SensorMode { get { return _sensorMode; } set { _sensorMode = value; } }
        private IValueGenerator _generator;
        private Guid _id = Guid.NewGuid();
        public Guid Id { get { return _id; } set { _id = value; } }
        private int _measurementInterval;
        public int MeasurementInterval { get { return _measurementInterval; } set { _measurementInterval = value; } }
        private SensorTypes _sensorType;
        public SensorTypes SensorType { get { return _sensorType; } set { _sensorType = value; } }
        private int _measuredValue;
        public int MeasuredValue { get => _measuredValue; set => _measuredValue = value; }
        public Sensor(SensorConfiguration configuration)
        {
            Id = Guid.NewGuid();
            MeasurementInterval = configuration.MeasurementInterval;
            SensorType = configuration.SensorType;
            SensorMode = _sensorMode;
            //SwitchMode();
        }
        public void SwitchMode()
        {
            if (_sensorMode == SensorModes.Idle)
            {
                _sensorMode = SensorModes.Calibration;
                _generator = new CalibrationValueGenerator();
                _generator.GetMeasuredValue(_measuredValue);
            }
            if (_sensorMode == SensorModes.Calibration)
            {
                _sensorMode = SensorModes.Working;
                _generator = new WorkingValueGenerator();
                _generator.GetMeasuredValue(_measuredValue);
            }
            if (_sensorMode == SensorModes.Working)
            {
                _sensorMode = SensorModes.Idle;
                _generator = new IdleValueGenerator();
                _generator.GetMeasuredValue(_measuredValue);
            }
        }
    }
}