using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using XMLFileHandler.Entities;
using XMLFileHandler.Interfaces;

namespace XMLFileHandler
{

    public class XmlWriter   
    {
        private readonly string _filePath;
        private IConfig _config;
        public XmlWriter(string filePath, Config config)
        {
            _filePath = filePath;
            _config = config;
        }
        public XmlWriter() { }

        public void SaveToXml()
        {
            var serializer = new XmlSerializer(typeof(List<User>));
            using (var stream = new FileStream(_filePath, FileMode.Create))
            {
                serializer.Serialize(stream, _config.GetUsers());
            }
            Console.WriteLine("Saved!");
        }
    }
}
