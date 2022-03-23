
using XMLFileHandler.Entities;
try
{
    var alexMainWindow = new Window("main", "10", "40", "400", "200");
    var userAlex = new User("alex", alexMainWindow, null);

    var sarahMainWindow = new Window("main", null, "20", "400", "200");
    var sarahHelpWindow = new Window("help", "10", "30", null, "100");
    var userSarah = new User("sarah", sarahMainWindow, sarahHelpWindow);

    var annaMainWindow = new Window("main", "25", null, "350", "150");
    var userAnna = new User("anna", annaMainWindow, null);
    var config = new UserSettingsToXml();
    config.AddUser(userAlex);
    config.AddUser(userSarah);
    config.AddUser(userAnna);
    config.SaveToXml();

    var xmlToJson = new XMLFileHandler.UserSettingsFromXmlToJson();
    xmlToJson.DisplayIncorrectLogins();
}
catch (NullReferenceException)
{
    Console.WriteLine("This field cannot be null or empty.");
}
