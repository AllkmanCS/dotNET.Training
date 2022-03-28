namespace ListenersConfigurationLibrary.Interfaces
{
    public interface IListener
    {
        void Write(string message);
        string MinLogLevel { get; }
    }
}
