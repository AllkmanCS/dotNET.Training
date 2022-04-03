using System.Text.Json;
using XMLFileHandler.Interfaces;

namespace XMLFileHandler
{
    internal class JsonWriter
    {
        private readonly string _jsonPath;
        private readonly IXmlParser _xmlParser;
        public JsonWriter(XmlParser xmlParser, string jsonPath)
        {
            _xmlParser = xmlParser;
            _jsonPath = jsonPath;
        }
        public void DisplayIncorrectLogins()
        {
            var usersLogins = _xmlParser.LoadUsersXml();

            var options = new JsonSerializerOptions { WriteIndented = true };

            foreach (var login in usersLogins)
            {
                foreach (var item in login.Windows)
                {
                    if (item.Top == null || item.Left == null || item.Width == null || item.Height == null)
                    {
                        item.SetDefaultValues();
                        string jsonString = JsonSerializer.Serialize(login, options);
                        Console.WriteLine(jsonString);
                        File.WriteAllText(_jsonPath + login.Name + ".json", jsonString);
                    }
                }
            }
        }
    }
}