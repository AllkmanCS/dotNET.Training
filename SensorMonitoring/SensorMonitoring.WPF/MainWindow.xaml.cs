using SensorMonitor.BL;
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
        private ObservableCollection<Sensor> _sensors = new ObservableCollection<Sensor>();
        private string _jsonFileName = @"C:\Users\AlgirdasCernevicius\source\repos\dotNET.Training\SensorMonitoring\Sensors.DAL\Data\jsonSettings.json";
        private string _xmlFileName = Path.Combine(
Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName,
@"Data\xmlSettings.xml");
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Initialized(object sender, EventArgs e)
        {
            if (_jsonCreator is null)
            {
                this.sensorsDataGrid.ItemsSource = _sensors;
            }
            else
            {
                this.sensorsDataGrid.ItemsSource = _jsonCreator.Read(_jsonFileName);
            }
        }
        private void ChangeSensorMode(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteSensor(object sender, RoutedEventArgs e)
        {

        }
        private void AddSensor(object sender, RoutedEventArgs e)
        {
            // if(SensorTypes.Pressure)from ListBox
            if (true)
            {

            }
            Console.WriteLine();
        }

        private void SwitchDataBase(object sender, RoutedEventArgs e)
        {

        }
    }
}
