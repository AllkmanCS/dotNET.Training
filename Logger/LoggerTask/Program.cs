using LoggerTask;
using LoggerTask.TestClasses;

    Logger logger = new Logger();
var testOne = new TestOne(12, "Text1", "Text2", 80000, 4033);    
logger.Track(testOne, 2);
