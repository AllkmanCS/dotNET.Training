using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2.One.ElectronicCatalog.Entities
{
    public class Book
    {
        private string _isbn;
        private string _title;
        //a set to add unique authors
        public HashSet<Author> Authors = new HashSet<Author>();
        public DateTime Date;
        private string _v;
        private HashSet<Author> _authors;
        private DateTime _dateTime;
        private static readonly Regex _isbnWithHyphens = new Regex(@"^[0-9]*[-][0-9]*[-][0-9]*[-][0-9]*[-][0-9]*");
        private static readonly Regex _isbnDigitsOnly = new Regex(@"^[0-9]{13}$");
        private const int _maxLength = 1000;
        public string Isbn
        {
            get
            {
                if (!IsValidIsbn(_isbn))
                {
                    _isbn = null;
                    throw new ArgumentException();
                }
                return _isbn;
            }
            set
            {
                if (IsValidIsbn(value))
                {
                    _isbn = value;
                    if (_isbnWithHyphens.IsMatch(_isbn))
                    {
                        string normalizedISBN = Regex.Replace(_isbn, @"[^0-9]", "");
                        _isbn = normalizedISBN;
                    }
                }
            }
        }
        public string Title 
        { 
            get
            {
                if (_title.Length > _maxLength)
                    _title.Substring(0, _maxLength);

                return _title;
            }
            set => _title = value; 
        }
        public Book(string isbn, string title, HashSet<Author> authors, DateTime date)
        {
            Isbn = isbn;
            if (!string.IsNullOrEmpty(title))
            {
                _title = title;
            }
            else
            {
                throw new ArgumentNullException();
            }
            Authors = authors;
            Date = date;
        }

        public Book(string v, HashSet<Author> authors, DateTime dateTime)
        {
            _v = v;
            _authors = authors;
            _dateTime = dateTime;
        }

        private bool IsValidIsbn(string isbn)
        {
            if (isbn == null)
            {
                throw new NullReferenceException();
            }
            else if (_isbnWithHyphens.Match(isbn).Success)
            {
                return true;
            }
            else if (_isbnDigitsOnly.Match(isbn).Success)
            {
                return true;
            }
            else
            {
                throw new ArgumentException();
            }
            return _isbn != null;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(_title);
            sb.AppendLine(Date.ToString());
            sb.AppendLine("Author (-s):");
            foreach (var author in Authors)
            {
                sb.Append($"{author} \n");
            }
            return sb.ToString();
        }
    }
}
