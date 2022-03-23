using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XMLFileHandler.Entities;

namespace XMLFileHandler
{
    internal class UserSettingsFromXmlToJson
    {
        private readonly static string xmlFile = "C:/Users/AlgirdasCernevicius/source/repos/dotNET.Training/XMLFileHandler/XMLFileHandler/Config" + @"\config.xml";
        private readonly static string jsonPath = "C:/Users/AlgirdasCernevicius/source/repos/dotNET.Training/XMLFileHandler/XMLFileHandler/Config/";
        public void DisplayIncorrectLogins()
        {
            var xml = XDocument.Load(xmlFile);
            var logins = GetLogins(xml);

            var options = new JsonSerializerOptions { WriteIndented = true };

            foreach (var login in logins)
            {
                foreach (var item in login.Windows)
                {
                    if (item.Top == null || item.Left == null || item.Width == null || item.Height == null)
                    {
                        string jsonString = JsonSerializer.Serialize(login, options);
                        Console.WriteLine(jsonString);
                        File.WriteAllText(jsonPath + login.Name + ".json", jsonString);
                    }
                }
            }
        }
        private List<User> GetLogins(XDocument xml)
        {
            var logins = (from login in xml.Descendants("login")
                          select new User
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