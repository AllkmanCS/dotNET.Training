using SensorMonitor.BL;
using Sensors.DAL.Configurations;
using Sensors.DAL.Enums;
using Sensors.DAL.Factory;
using Sensors.DAL.Factory.Factory;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace SensorMonitoring.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ISensorConfigurationReader _jsonCreator = ConfigurationReaderCreator.CreateConfigurationReader(SensorConfigurationFileTypes.Json);
        ISensorConfigurationReader _xmlCreator = ConfigurationReaderCreator.CreateConfigurationReader(SensorConfigurationFileTypes.Xml);
        private string _jsonFileName = @"C:\Users\AlgirdasCernevicius\source\repos\dotNET.Training\SensorMonitoring\Sensors.DAL\Data\jsonSettings.json";
        private string _xmlFileName = @"C:\Users\AlgirdasCernevicius\source\repos\dotNET.Training\SensorMonitoring\Sensors.DAL\Data\xmlSettings.xml";
        private ObservableCollection<Sensor> _sensors = new ObservableCollection<Sensor>();
        ObservableCollection<ISensorConfigurationReader> _sensorSettings = new ObservableCollection<ISensorConfigurationReader>();
        public ObservableCollection<ISensorConfigurationReader> SensorSettings
        {
            get
            {
                _sensorSettings.Add(_jsonCreator);
                _sensorSettings.Add(_xmlCreator);
                return _sensorSettings;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        private void Window_Initialized(object sender, EventArgs e)
        {
            this.sensorsDataGrid.ItemsSource = _sensors;
        }
        private void ChangeSensorMode(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteSensor(object sender, RoutedEventArgs e)
        {

        }
        private void AddSensor(object sender, RoutedEventArgs e)
        {
            foreach (var item in _sensorSettings)
            {
                string sensorTypeName = sensorType.Text;
                if (item == _sensorSettings[0])
                {
                    var sensorTypes = _jsonCreator.Read(_jsonFileName);
                    foreach (var sensorType in sensorTypes.Sensors)
                    {
                        switch ((SensorTypes)Enum.Parse(typeof(SensorTypes), sensorTypeName))
                        {
                            case SensorTypes.MagneticField:
                                _sensors.Add(new Sensor(sensorType));
                                break;
                            case SensorTypes.Pressure:
                                _sensors.Add(new Sensor(sensorType));
                                break;
                            case SensorTypes.Temperature:
                                _sensors.Add(new Sensor(sensorType));
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    var sensorTypes = _xmlCreator.Read(_xmlFileName);
                    foreach (var sensorType in sensorTypes.Sensors)
                    {
                        switch ((SensorTypes)Enum.Parse(typeof(SensorTypes), sensorTypeName))
                        {
                            case SensorTypes.MagneticField:
                                _sensors.Add(new Sensor(sensorType));
                                break;
                            case SensorTypes.Pressure:
                                _sensors.Add(new Sensor(sensorType));
                                break;
                            case SensorTypes.Temperature:
                                _sensors.Add(new Sensor(sensorType));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
