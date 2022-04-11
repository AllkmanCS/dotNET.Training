using XMLFileHandler;
using XMLFileHandler.Entities;

const string xmlFile = "C:/Users/AlgirdasCernevicius/source/repos/dotNET.Training/XMLFileHandler/XMLFileHandler/Config" + @"\config.xml";
const string jsonPath = "C:/Users/AlgirdasCernevicius/source/repos/dotNET.Training/XMLFileHandler/XMLFileHandler/Config/";

try
{
    var alexMainWindow = new Window("main", null, "80", "400", "200");
    var userAlex = new User("alex", alexMainWindow, null);

    var sarahMainWindow = new Window("main", "10", "50", "400", "200");
    var sarahHelpWindow = new Window("help", null, "30", null, "100");
    var userSarah = new User("sarah", sarahMainWindow, sarahHelpWindow);

    var annaMainWindow = new Window("main", "105", null, "350", "150");
    var userAnna = new User("anna", annaMainWindow, null);
    var users = new List<User>();
    users.Add(userAlex);
    users.Add(userSarah);
    users.Add(userAnna);
    var config = new Config(users);

    var xmlWriter = new XmlConfigWriter(xmlFile, config);

    xmlWriter.SaveToXml();

    var xmlParser = new XmlParser(xmlFile);
    var xmlToJson = new JsonConfigWriter(xmlParser, jsonPath);
    xmlToJson.DisplayIncorrectLogins();
}
catch (NullReferenceException)
{
    Console.WriteLine("This field cannot be null or empty.");
}
