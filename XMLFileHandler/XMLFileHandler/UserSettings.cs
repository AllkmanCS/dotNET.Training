using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLFileHandler
{
    internal class UserSettings
    {
        private readonly static string _name;
        private readonly static string _top;
        private readonly static string _left;
        private readonly static string _width;
        private readonly static string _height;
        public UserSettings(string name, string top, string left, string width, string height)
        {

        }
        // 2. Save the XML Document to the disk
        // 
        private static readonly XNamespace empNM = "urn:lst-emp:emp";
        private static readonly object config = "config";
        public void WriteToXml()
        {

        XDocument xDoc = new XDocument(
                    new XDeclaration("1.0", "UTF-16", null),
                    new XElement(empNM + "config",
                        new XElement("login",_name,
                            new XElement("window",
                            new XElement("top", _top),
                            new XElement("left", _left),
                            new XElement("width", _width),
                            new XElement("height", _height)
                            ))));

        xDoc.Save(AppDomain.CurrentDomain.BaseDirectory +"\\Config"/*"C:\\Something.xml"*/);
        Console.WriteLine("Saved");
        }

        //// Save to Disk
        //xDoc.Save("C:\\Something.xml");
        //Console.WriteLine("Saved");

        // 3. Load an XML Document using XML Reader           
        //XmlReader xRead = XmlReader.Create(@"..\\..\\Employees.xml");
        //XElement xEle = XElement.Load(xRead);
        //Console.WriteLine(xEle);
        //xRead.Close();
    }
}
