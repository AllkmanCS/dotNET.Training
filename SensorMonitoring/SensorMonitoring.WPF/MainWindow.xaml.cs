using SensorMonitoring.DAL.Factory.XmlCreator;
using Sensors.DAL.Entities;
using Sensors.DAL.Factory.Factory;
using Sensors.DAL.Factory.JsonCreator;
using Sensors.DAL.Factory.XmlCreator;
using System;
using System.Collections.Generic;
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
        private SensorFactory _jsonSensorsFactory = new SensorJsonReader();
        private SensorFactory _xmlSensorsFactory = new SensorXmlFactory();
        private string _jsonFileName = @"C:\Users\AlgirdasCernevicius\source\repos\dotNET.Training\SensorMonitoring\Sensors.DAL\Data\PrimaryDb.json";
        private string _xmlFileName = Path.Combine(
Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName,
@"Data\SecondaryDb.xml");
        public MainWindow()
        {
            InitializeComponent();

            
        }
        private void Window_Initialized(object sender, EventArgs e)
        {
            if (_jsonSensorsFactory is null)
            {
                this.sensorsDataGrid.ItemsSource = _xmlSensorsFactory.GetSensors(_xmlFileName);
            }
            else
            {
                this.sensorsDataGrid.ItemsSource = _jsonSensorsFactory.GetSensors(_jsonFileName);
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
            var sensorsTypes = new List<Type>() { typeof(MagneticFieldSensor), typeof(PressureSensor), typeof(TemperatureSensor) };
            Console.WriteLine(sensorsTypes.Count);
        }

        private void SwitchDataBase(object sender, RoutedEventArgs e)
        {

        }
    }
}
