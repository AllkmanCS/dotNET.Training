using System.Xml.Linq;
using XMLFileHandler.Entities;

namespace XMLFileHandler.Interfaces
{
    public interface IXmlParser
    {
        List<User> LoadUsersXml();
    }
}