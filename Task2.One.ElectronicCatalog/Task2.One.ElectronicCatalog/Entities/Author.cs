using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.One.ElectronicCatalog.Entities
{
    public class Author
    {
        private const int _maxLength = 200;
        private string _firstName;
        private string _lastName;
        public HashSet<Book> Books = new HashSet<Book>();
        public string FirstName
        {
            get => StringLengthValidation(_firstName, _maxLength);
            set => _firstName = value;
        }
        public string LastName
        {
            get => StringLengthValidation(_lastName, _maxLength);
            set => _lastName = value;
        }
        private string StringLengthValidation(string text, int maxLength)
        {
            if (text.Length > maxLength)
                text.Substring(0, maxLength);

            return text;
        }
        public Author(string firstName, string lastName)
        {
            if (!string.IsNullOrEmpty(firstName))
                _firstName = firstName;

            if (!string.IsNullOrEmpty(lastName))
                _lastName = lastName;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            Author emp = (Author)obj;
            return (this.FirstName, this.LastName) == (emp.FirstName, emp.LastName);
        }
    }
}
 