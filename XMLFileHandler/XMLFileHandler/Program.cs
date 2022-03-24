using XMLFileHandler;
using XMLFileHandler.Entities;

const string xmlFile = "C:/Users/AlgirdasCernevicius/source/repos/dotNET.Training/XMLFileHandler/XMLFileHandler/Config" + @"\config.xml";
const string jsonPath = "C:/Users/AlgirdasCernevicius/source/repos/dotNET.Training/XMLFileHandler/XMLFileHandler/Config/";

try
{

    var alexMainWindow = new Window("main", "10", "40", "400", "200");
    var userAlex = new Config("alex", alexMainWindow, null);

    var sarahMainWindow = new Window("main", null, "", "400", "200");
    var sarahHelpWindow = new Window("help", "10", "30", null, "100");
    var userSarah = new Config("sarah", sarahMainWindow, sarahHelpWindow);

    var annaMainWindow = new Window("main", "25", null, "350", "150");
    var userAnna = new Config("anna", annaMainWindow, null);
    var config = new ConfigToXml(xmlFile);
    config.AddUser(userAlex);
    config.AddUser(userSarah);
    config.AddUser(userAnna);
    config.SaveToXml();

    var xmlToJson = new ConfigToJson(xmlFile, jsonPath);
    xmlToJson.DisplayIncorrectLogins();
}
catch (NullReferenceException)
{
    Console.WriteLine("This field cannot be null or empty.");
}
