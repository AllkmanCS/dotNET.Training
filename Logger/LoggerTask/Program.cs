using LoggerTask;
using LoggerTask.TestClasses;

string jsonFile = "C:/Users/AlgirdasCernevicius/source/repos/dotNET.Training/Logger/LoggerTask/appsettings.json";
    Logger logger = new Logger(jsonFile);
var testOne = new TestOne(12, "Text1", "Text2", 80000, 4033);    
logger.Track(testOne, 2);
