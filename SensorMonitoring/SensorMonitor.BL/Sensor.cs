using SensorMonitor.BL.Interfaces;
using Sensors.DAL.Configurations;
using Sensors.DAL.Enums;
using Sensors.DAL.Factory;
using Sensors.DAL.Factory.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorMonitor.BL
{
    public class Sensor
    {
//        private string _jsonFileName = @"C:\Users\AlgirdasCernevicius\source\repos\dotNET.Training\SensorMonitoring\Sensors.DAL\Data\jsonSettings.json";
//        private string _xmlFileName = Path.Combine(
//Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName,
//@"Data\xmlSettings.xml");
//        ISensorConfigurationReader _jsonCreator = ConfigurationReaderCreator.CreateConfigurationReader(SensorConfigurationFileTypes.Json);
//        ISensorConfigurationReader _xmlCreator = ConfigurationReaderCreator.CreateConfigurationReader(SensorConfigurationFileTypes.Xml);
        SensorConfigurationFileTypes _configType;
        private Guid _id;
        private SensorTypes _sensorType;
        private float _measurementValue;
        private IValueGenerator _generator;
        private int _measurementInterval;

        //setting default sesnor mode
        private SensorModes _mode = SensorModes.Idle;
        public Sensor(SensorConfiguration configuration)
        {
            _id = configuration.Id;
            _sensorType = configuration.SensorType;
            _measurementInterval = configuration.MeasurementInterval;
        }
        public void SwitchMode(SensorModes mode)
        {
          
        }
        
    }
}
