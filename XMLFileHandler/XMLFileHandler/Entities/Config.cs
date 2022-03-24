using System.Xml.Serialization;

namespace XMLFileHandler.Entities
{
    [XmlRoot("config")]
    public class Config
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("window", Type = typeof(Window))]

        public List<Window> Windows { get; set; }
        private Window _mainWindow = new Window();
        private Window _helpWindow = new Window();
        public Config(string name, Window main, Window help)
        {
            Name = name;
            _mainWindow = main;
            _helpWindow = help;
            Windows = new List<Window>();
            Windows.Add(_mainWindow);
            Windows.Add(_helpWindow);
        }
        public Config(string name)
        {
            Name = name;
        }
        public Config() { }
    }
}
