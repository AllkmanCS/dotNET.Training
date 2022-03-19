// See https://aka.ms/new-console-template for more information
using XMLFileHandler;

Console.WriteLine("Hello, World!");
var userAlex = new UserSettings("alex", "10", "20", "400", "200");
userAlex.WriteToXml();