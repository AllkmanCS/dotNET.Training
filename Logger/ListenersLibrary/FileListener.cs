using ListenersConfigurationLibrary.Interfaces;
using ListenersConfigurationLibrary.ListenerConfigurations;

namespace ListenersLibrary
{
    public class FileListener : IListener
    {
        public string FileName { get; set; }
        public string MinLogLevel { get; set; }
        public FileListener(FileListenerConfiguration configuration)
        {
            FileName = configuration.FileName;
            MinLogLevel = configuration.MinLogLevel;
        }
        public FileListener() { }
        public void Write(string message)
        {
            if (File.Exists(FileName))
            {
                //writes to file
                File.WriteAllText(FileName, message);
            }
            else
            {
                // Create the file.
                using (FileStream fs = File.Create(FileName))
                {
                    File.WriteAllText(FileName, message);
                }
            }
        }
    }
}
