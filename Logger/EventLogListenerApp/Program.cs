using EventLogListenerApp;
using ListenersConfigurationLibrary.ListenersConfigurations;
using Microsoft.Extensions.Configuration;


    var eventLogListener = new EventLogListener();
    Console.WriteLine(eventLogListener.EventLogName);
    Console.WriteLine(eventLogListener.MinLogLevel);

    Console.WriteLine(eventLogListener);
