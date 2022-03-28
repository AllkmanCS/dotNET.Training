using ListenersConfigurationLibrary.Interfaces;
using ListenersConfigurationLibrary.ListenerConfigurations;

namespace ListenersLibrary.Listeners
{
    public class FileListener : IListener
    {
        private string _fileName;
        private int _minLogLevel;
        public string MinLogLevel { get; }
        public FileListener(FileListenerConfiguration configuration)
        {
            _fileName = configuration.FileName;
            MinLogLevel = configuration.MinLogLevel;
        }


        public void Write(string message)
        {
            if (File.Exists(_fileName))
            {
                //writes to file
                File.WriteAllText(_fileName, message);
            }
            else
            {
                // Create the file.
                using (FileStream fs = File.Create(_fileName))
                {
                    File.WriteAllText(_fileName, message);
                }
            }
        }
    }
}
