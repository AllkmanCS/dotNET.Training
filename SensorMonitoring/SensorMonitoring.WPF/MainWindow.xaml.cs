using SensorMonitor.BL;
using Sensors.DAL.Configurations;
using Sensors.DAL.Data;
using Sensors.DAL.Enums;
using Sensors.DAL.Factory;
using Sensors.DAL.Factory.Factory;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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
        private ObservableCollection<ISensorConfigurationReader> _sensorSettings = new ObservableCollection<ISensorConfigurationReader>();
        private SensorsSettings _selectedSensorSettings = new SensorsSettings();
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
            string sensorTypeName = sensorType.Text;

            foreach (var sensorType in _selectedSensorSettings.Sensors)
            {
                if (sensorType.SensorType == (SensorTypes)Enum.Parse(typeof(SensorTypes), sensorTypeName))
                {
                    _sensors.Add(new Sensor(sensorType));
                }
            }
        }
        private void sensorSettings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sensorSettingsLabel.Content = ((TextBlock)((sender as ListBox).SelectedItem as ListBoxItem).Content).Text;

            if (sensorSettingsLabel.Content.ToString() == "Json Settings")
            {
                _selectedSensorSettings = _jsonCreator.Read(_jsonFileName);
                Console.WriteLine("JSON");
            }
            if (sensorSettingsLabel.Content.ToString() == "Xml Settings")
            {
                _selectedSensorSettings = _xmlCreator.Read(_xmlFileName);
                Console.WriteLine("XML");
            }
        }
    }
}