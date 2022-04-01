using ListenersConfigurationLibrary.Enums;
using ListenersConfigurationLibrary.Interfaces;
using ListenersConfigurationLibrary.ListenerConfigurations;
using ListenersConfigurationLibrary.ListenersConfigurations;
//using ListenersLibrary.Listeners;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Text;

namespace LoggerTask
{
    public class Logger
    {
        public List<IListener> _listeners = new List<IListener>();
        private string[] _paths = { "ListenersLibrary.FileListener", "ListenersLibrary.WordListener", "ListenersLibrary.EventLogListener" };
        private string _propertyAttributeName;
        private string _propertyValue;
        private string _fieldAttributeName;
        private string _fieldValue;
        private string _fileName;
        private string _minLogLevel;
        private string _eventLogName;

        public Logger()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
               .AddJsonFile(@"C:/Users/AlgirdasCernevicius/source/repos/dotNET.Training/Logger/LoggerTask/appsettings.json");
            var config = builder.Build();
            foreach (var item in _paths)
            {
                switch (item)
                {
                    case "ListenersLibrary.FileListener":
                        var fileListenerConfiguration = config.GetSection(FileListenerConfiguration.SectionName)
                            .Get<FileListenerConfiguration>();
                        _fileName = fileListenerConfiguration.FileName;
                        _minLogLevel = fileListenerConfiguration.MinLogLevel;
                        _listeners.Add(GetListener(_paths[0], _fileName, _minLogLevel));
                        break;
                    case "ListenersLibrary.WordListener":
                        var wordListenerConfiguration = config.GetSection(WordListenerConfiguration.SectionName)
                            .Get<WordListenerConfiguration>();
                        _fileName = wordListenerConfiguration.FileName;
                        _minLogLevel = wordListenerConfiguration.MinLogLevel;
                        _listeners.Add(GetListener(_paths[1], _fileName, _minLogLevel));
                        break;
                    case "ListenersLibrary.EventLogListener":
                        var eventLogConfiguration = config.GetSection(EventLogListenerConfiguration.SectionName)
                            .Get<EventLogListenerConfiguration>();
                        _eventLogName = eventLogConfiguration.EventLogName;
                        _minLogLevel = eventLogConfiguration.MinLogLevel;
                        _listeners.Add(GetListener(_paths[2], _eventLogName, _minLogLevel));
                        break;
                    default:
                        break;
                }
            }
        }
        private IListener GetListener(string listenerName, string name, string minLogLevel)
        {
            Assembly listenerAssembly = Assembly.LoadFrom("C:/Users/AlgirdasCernevicius/source/repos/dotNET.Training/Logger/ListenersLibrary/bin/Debug/net6.0/ListenersLibrary.dll");
            Type listenerType = listenerAssembly.GetType(listenerName);
            object instance = Activator.CreateInstance(listenerType);
            foreach (var item in instance.GetType().GetRuntimeProperties())
            {
                if (item.Name == "FileName")
                {
                    name = _fileName;
                    item.SetValue(instance, name);
                }
                else if (item.Name == "EventLogName")
                {
                    name = _eventLogName;
                    item.SetValue(instance, name);
                }
                else if (item.Name == "MinLogLevel")
                {
                    minLogLevel = _minLogLevel;
                    item.SetValue(instance, minLogLevel);
                }
            }
            return instance as IListener;
        }
        public void Track(object obj, int logLevel)
        {
            string message = ConvertToString(obj);
            foreach (var listener in _listeners)
            {
                var minLoglevel = Enum.Parse(typeof(LogLevel), listener.MinLogLevel, true);
                int logLevelValue = (int)minLoglevel;
                if (logLevel > logLevelValue)
                {
                    listener.Write(message);
                }
            }
        }
        private string ConvertToString(object obj)
        {
            var sb = new StringBuilder();
            var classAttributes = obj.GetType().GetCustomAttributes(true);
            foreach (var classAttibute in classAttributes)
            {
                if (classAttibute is TrackingEntityAttribute)
                {
                    foreach (var property in obj.GetType().GetProperties())
                    {
                        _propertyAttributeName = ((TrackingPropertyAttribute)property.GetCustomAttribute(typeof(TrackingPropertyAttribute)))?.Name;
                        _propertyValue = property.GetValue(obj).ToString();
                        if (_propertyAttributeName is null)
                        {
                            _propertyAttributeName = property.Name;
                        }
                        sb.AppendJoin('=', _propertyAttributeName, _propertyValue);
                    }
                    foreach (var field in obj.GetType().GetFields())
                    {
                        _fieldAttributeName = ((TrackingPropertyAttribute)field.GetCustomAttribute(typeof(TrackingPropertyAttribute)))?.Name;
                        _fieldValue = field.GetValue(obj).ToString();
                        if (_fieldAttributeName is null)
                        {
                            _fieldAttributeName = field.Name;
                        }
                        sb.AppendJoin("=", _fieldAttributeName, _fieldValue);
                    }
                }
            }
            return sb.ToString();
        }
    }
}
