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
            IConfigurationBuilder builder = new ConfigurationBuilder()
                    .AddJsonFile(@"C:\Users\AlgirdasCernevicius\source\repos\dotNET.Training\Logger\FileListenerLibrary\fileListenerSettings.json");
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