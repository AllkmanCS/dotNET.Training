using ListenersConfigurationLibrary.Enums;
using ListenersConfigurationLibrary.Interfaces;
using ListenersConfigurationLibrary.ListenerConfigurations;
using ListenersConfigurationLibrary.ListenersConfigurations;
using ListenersLibrary.Listeners;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Text;

namespace LoggerTask
{
    public class Logger
    {
        public List<IListener> _listeners = new List<IListener>();
        private string[] paths = { "fileListener", "wordListener", "eventLogListener" };
        private string _propertyAttributeName;
        private string _propertyValue;
        private string _fieldAttributeName;
        private string _fieldValue;
        private static readonly Dictionary<string, string> log = new Dictionary<string, string>();

        public Logger()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
               .AddJsonFile(@"C:/Users/AlgirdasCernevicius/source/repos/dotNET.Training/Logger/LoggerTask/appsettings.json");
            var config = builder.Build();
            foreach (var item in paths)
            {
                switch (item)
                {
                    case "fileListener":
                        var fileListenerConfiguration = config.GetSection(FileListenerConfiguration.SectionName)
                            .Get<FileListenerConfiguration>();
                        _listeners.Add(new FileListener(fileListenerConfiguration));
                        break;
                    case "wordListener":
                        var wordListenerConfiguration = config.GetSection(WordListenerConfiguration.SectionName)
                            .Get<WordListenerConfiguration>();
                        _listeners.Add(new WordListener(wordListenerConfiguration));
                        break;
                    case "eventLogListener":
                        var eventLogConfiguration = config.GetSection(EventLogListenerConfiguration.SectionName)
                            .Get<EventLogListenerConfiguration>();
                        _listeners.Add(new EventLogListener(eventLogConfiguration));
                        break;
                    default:
                        break;
                }
            }
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
