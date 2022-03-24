using System.Text.Json;
using System.Xml.Linq;
using XMLFileHandler.Entities;

namespace XMLFileHandler
{
    internal class ConfigToJson
    {
        private readonly string _xmlFile;
        private readonly string _jsonPath;
        public ConfigToJson(string xmlFile, string jsonPath)
        {
            _xmlFile = xmlFile;
            _jsonPath = jsonPath;
        }
        public void DisplayIncorrectLogins()
        {
            var xml = XDocument.Load(_xmlFile);
            var logins = GetLogins(xml);

            var options = new JsonSerializerOptions { WriteIndented = true };

            foreach (var login in logins)
            {
                foreach (var item in login.Windows)
                {
                    if (item.Top == null || item.Left == null || item.Width == null || item.Height == null)
                    {
                        //setting default values just before serializing to Json files
                        item.SetDefaultValues();
                        string jsonString = JsonSerializer.Serialize(login, options);
                        Console.WriteLine(jsonString);
                        //TODO I should refactor it with using(var stream... )
                        File.WriteAllText(_jsonPath + login.Name + ".json", jsonString);
                    }
                }
            }
        }
        private List<Config> GetLogins(XDocument xml)
        {
            var logins = (from login in xml.Descendants("login")
                          select new Config
                          {
                              Name = login.Attribute("name").Value,
                              Windows = GetWindows(login),
                          }).ToList();
            return logins;
        }
        private List<Window> GetWindows(XElement login)
        {
            var windows = (from window in login.Descendants("window")
                           select new Window
                           {
                               Title = window.Attribute("title").Value,
                               Top = window.Element("Top")?.Value,
                               Left = window.Element("Left")?.Value,
                               Width = window.Element("Width")?.Value,
                               Height = window.Element("Height")?.Value,
                           }).ToList();
            return windows;
        }
    }
}