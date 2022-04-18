using ListenersConfigurationLibrary.Enums;
using ListenersRepository;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace LoggerTask
{
    public class Logger
    {
        private List<IListener> _listeners = new List<IListener>();
        private readonly string _jsonFile;

        public Logger(string jsonFile)
        {
            _jsonFile = jsonFile;
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile(_jsonFile);
            var cfg = builder.Build();
            var listeners = cfg.GetSection("Listeners").Get<List<List<string>>>();
            foreach (var listener in listeners)
            {
                Assembly assembly = Assembly.LoadFrom(listener[1]);
                
                string assemblyFullName = listener[0];
                Type type = assembly.GetType(assemblyFullName);
                object instance = Activator.CreateInstance(type);
                var iListener = instance as IListener;
                _listeners.Add(iListener);
            }
        }
        public void Track(object obj, int logLevel)
        {
            string message = ObjectToStringConverter.ConvertToString(obj);
            foreach (var listener in _listeners)
            {
                var minlogLevel= listener.GetType().GetRuntimeProperty("MinLogLevel").GetValue(listener).ToString();
                var logLevelValue = (int)Enum.Parse(typeof(LogLevel), minlogLevel, true);
                if (logLevel > logLevelValue)
                {
                    listener.Write(message);
                }
            }
        }
    }
}