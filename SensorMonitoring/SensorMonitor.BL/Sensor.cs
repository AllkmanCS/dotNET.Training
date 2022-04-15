using SensorMonitor.BL.Interfaces;
using SensorMonitor.BL.MeasuredValueGenerators;
using Sensors.DAL.Configurations;
using Sensors.DAL.Enums;
using Sensors.DAL.Factory;
using Sensors.DAL.Factory.Factory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorMonitor.BL
{
    public class Sensor
    {

        //setting default sesnor mode
        private SensorModes _mode = SensorModes.Idle;
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
            _measurementInterval = configuration.MeasurementInterval;
            _sensorType = configuration.SensorType;
        }
        public void SwitchMode(SensorModes mode)
        {
            mode = _mode;
            if (mode == SensorModes.Idle)
            {
                _generator = new CalibrationValueGenerator();
                _generator.GetMeasuredValue(_measuredValue);
             
            }
            if (mode == SensorModes.Calibration)
            {
                _generator = new WorkingValueGenerator();
                _generator.GetMeasuredValue(_measuredValue);
            } 
            if (mode == SensorModes.Working)
            {
                _generator = new IdleValueGenerator();
                _generator.GetMeasuredValue(_measuredValue);
            }
        }
    }
}