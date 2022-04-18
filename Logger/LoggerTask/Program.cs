using LoggerTask;
using LoggerTask.TestClasses;

string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\appsettings.json");
string jsonFile = Path.GetFullPath(sFile);
Logger logger = new Logger(jsonFile);
var testOne = new TestOne(12, "Text1", "Text2", 80000, 9033);    
logger.Track(testOne, 2);
