using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLFileHandler.Entities
{
    [XmlRoot("config")]
    public class User
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("window", Type = typeof(Window))]

        public List<Window> Windows { get; set; }
        private Window _mainWindow = new Window();
        private Window _helpWindow = new Window();
        public User(string name, Window main, Window help)
        {
            Name = name;
            _mainWindow = main;
            _helpWindow = help;
            Windows = new List<Window>();
            Windows.Add(_mainWindow);
            Windows.Add(_helpWindow);
        }
        public User(string name) 
        {
            Name = name;
        }
        public User() { }
    }
}
