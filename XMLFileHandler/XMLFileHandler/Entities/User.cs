using System.Xml.Serialization;

namespace XMLFileHandler.Entities
{
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
            //adding windows in ctor so that I could restrict user login to have null or 2 windows only
            Windows.Add(_mainWindow);
            Windows.Add(_helpWindow);
        }
        public User() { }
    }    
}
