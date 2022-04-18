using ListenersConfigurationLibrary.ListenerConfigurations;
using ListenersRepository;
using Microsoft.Extensions.Configuration;

namespace FileListenerLibrary
{
    public class FileListener : IListener
    {
        public string FileName { get; set; }
        public string MinLogLevel { get; set;  }
        public FileListener()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\fileListenerSettings.json");
            string jsonFile = Path.GetFullPath(sFile);
            IConfigurationBuilder builder = new ConfigurationBuilder()
                    .AddJsonFile(jsonFile);
            var config = builder.Build();
            var fileListenerConfig = config.GetSection(FileListenerConfiguration.SectionName)
                .Get<FileListenerConfiguration>();
            FileName = fileListenerConfig.FileName;
            MinLogLevel = fileListenerConfig.MinLogLevel;
        }

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