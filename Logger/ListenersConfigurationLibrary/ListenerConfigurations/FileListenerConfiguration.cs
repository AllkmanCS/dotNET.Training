namespace ListenersConfigurationLibrary.ListenerConfigurations
{
    public class FileListenerConfiguration
    {
        public string FileName { get; set; }
        public string MinLogLevel { get; set; }
        public const string SectionName = "fileListener";

    }
}
