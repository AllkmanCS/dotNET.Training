using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace XMLFileHandler.Entities
{
    [XmlRoot("config")]
    public class UserSettingsToXml   
    {
        private readonly static string path = "C:/Users/AlgirdasCernevicius/source/repos/dotNET.Training/XMLFileHandler/XMLFileHandler/Config" + @"\config.xml";
        [XmlElement("login", Type = typeof(User))]
        public List<User> Users { get; set; } = new List<User>();
        public UserSettingsToXml() { }
        public void AddUser(User user)
        {
            Users.Add(user);
        }
        public void SaveToXml()
        {
            var serializer = new XmlSerializer(typeof(UserSettingsToXml));
            using (var stream = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(stream, this);
            }
            Console.WriteLine("Saved!");
        }
        public UserSettingsToXml LoadXmlFile()
        {
            var serializer = new XmlSerializer(typeof(UserSettingsToXml));
            using (var stream = new FileStream(path, FileMode.Open))
            {
                return serializer.Deserialize(stream) as UserSettingsToXml;
            }
        }
    }
}
