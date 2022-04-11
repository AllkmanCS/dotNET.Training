using System.Xml.Serialization;
using XMLFileHandler.Entities;

namespace XMLFileHandler
{
    public class XmlConfigWriter
    {
        private readonly string _filePath;
        private Config _config = new Config();
        public XmlConfigWriter(string filePath, Config config)
        {
            _filePath = filePath;
            _config = config;
        }
        public XmlConfigWriter() { }
        public void SaveToXml()
        {
            var serializer = new XmlSerializer(typeof(Config));
            using (var stream = new FileStream(_filePath, FileMode.Create))
            {
                serializer.Serialize(stream, this._config);
            }
        }
    }
}
