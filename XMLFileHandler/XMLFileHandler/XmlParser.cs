using System.Xml.Linq;
using XMLFileHandler.Entities;
using XMLFileHandler.Interfaces;

namespace XMLFileHandler
{
    public class XmlParser : IXmlParser
    {
        private readonly string _xmlFile;
        public XmlParser(string xmlFile)
        {
            _xmlFile = xmlFile;
        }
        public List<User> LoadUsersXml()
        {
            var xml = XDocument.Load(_xmlFile);
            return GetUsersLogins(xml);
        }
        private List<User> GetUsersLogins(XDocument xml)
        {
            return (from login in xml.Descendants("login")
                          select new User
                          {
                              Name = login.Attribute("name").Value,
                              Windows = GetUserWindows(login),
                          }).ToList();
        }
        private List<Window> GetUserWindows(XElement userslogins)
        {
            var windows = from window in userslogins.Descendants("window")
                          select new Window
                          {
                              Title = window.Attribute("title").Value,
                              Top = window.Element("Top")?.Value,
                              Left = window.Element("Left")?.Value,
                              Width = window.Element("Width")?.Value,
                              Height = window.Element("Height")?.Value,
                          };
            return windows.ToList();
        }
    }
}
