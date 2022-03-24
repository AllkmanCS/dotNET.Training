using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using XMLFileHandler.Entities;

namespace XMLFileHandler
{
    [XmlRoot("config")]
    public class ConfigToXml   
    {
        private readonly string _filePath;
        [XmlElement("login", Type = typeof(Config))]
        public List<Config> Users { get; set; } = new List<Config>();
        public ConfigToXml(string filePath)
        {
            _filePath = filePath;
        }
        public ConfigToXml() { }
        public void AddUser(Config user)
        {
            Users.Add(user);
        }
        public void SaveToXml()
        {
            var serializer = new XmlSerializer(typeof(ConfigToXml));
            using (var stream = new FileStream(_filePath, FileMode.Create))
            {
                serializer.Serialize(stream, this);
            }
            Console.WriteLine("Saved!");
        }
    }
}
