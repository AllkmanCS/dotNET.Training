using System.Xml.Serialization;
using XMLFileHandler.Interfaces;

namespace XMLFileHandler.Entities
{
    [XmlRoot("config")]
    public class Config
    {
        [XmlElement("login", Type = typeof(User))]
        public List<User> _users { get; set; } = new List<User>();
        public Config(List<User> users)
        {
            _users = users;
        }
        public Config() { }
    }
}
