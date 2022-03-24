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
        public Window() { }
        public Window(string title, string top, string left, string width, string height)
        {
            Title = title;
            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }
        private bool IsValid(string coordinate)
        {
            return string.IsNullOrEmpty(coordinate) ? false : true;
        }
        public Window SetDefaultValues()
        {
            this.Top = IsValid(this.Top) ? this.Top = Top : this.Top = "0";
            this.Left = IsValid(this.Left) ? this.Left = Left : this.Left = "0";
            this.Width = IsValid(this.Width) ? this.Width = Width : this.Width = "400";
            this.Height = IsValid(this.Height) ? this.Height = Height : this.Height = "150";
            return this;
        }
    }
}
