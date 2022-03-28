using LoggerTask;
using LoggerTask.TestClasses;

    Logger logger = new Logger();
var testOne = new TestOne(12, "Text1", "Text2", 144, 33);    
logger.Track(testOne, 2);
