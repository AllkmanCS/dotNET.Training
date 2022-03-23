using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLFileHandler.Entities
{
    public class Window
    {
        private string _title;
        [XmlAttribute("title")]
        public string Title
        {
            get => !string.IsNullOrEmpty(_title) ? _title : throw new NullReferenceException();
            set => _title = value;
        }
        public string Top { get; set; }
        public string Left { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        //{ 
        //    get => !string.IsNullOrEmpty(_height) ? _height: "150"; 
        //    set => _height = value; 
        //}
        public Window() { }
        public Window(string title, string top, string left, string width, string height)
        {
            Title = title;
            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }
        //public override string ToString()
        //{
        //    var sb = new StringBuilder();

        //    sb.AppendLine($"Login: {Name}");
        //    sb.AppendLine($"main({Top}, {Left}, {Width}, {Height})");
        //    sb.AppendLine($"help({Top}, {Left}, {Width}, {Height})");
        //    return sb.ToString();
        //}
    }
}
