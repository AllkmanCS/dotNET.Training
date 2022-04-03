using System.Xml.Serialization;
using XMLFileHandler.Interfaces;

namespace XMLFileHandler.Entities
{
    [XmlRoot("config")]
    public class Config : IConfig
    {
        [XmlElement("login", Type = typeof(User))]
        private List<User> _users = new List<User>();
        public Config(List<User> users)
        {
            _users = users;
        }
        public Config()
        {

        }
        public List<User> GetUsers()
        {
            return _users.Where(x => x != null).ToList();
        }
    }
}
