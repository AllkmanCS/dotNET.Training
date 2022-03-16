using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.One.ElectronicCatalog.Entities
{
    internal class Author
    {
        private const int _maxLength = 200;
        private string _firstName;

        public string FirstName 
        {
            get { return _firstName; }
            set { _firstName = value; } 
        }
        public string LastName { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
