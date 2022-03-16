using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2.One.ElectronicCatalog.Entities
{
    internal class Book
    {
        private DateTime _date;
        private static readonly Regex _isbnWithHyphens = new Regex(@"^[0-9]*[-][0-9]*[-][0-9]*[-][0-9]*[-][0-9]*");
        private static readonly Regex _isbnDigitsOnly = new Regex(@"^[0-9]{13}$");
        private string _isbn;
        //a set to add unique authors
        private HashSet<Author> _authors;
        private string _title;

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
        public string Title { get => _title; set => _title = value; }
        public List<Author> Authors { get; set; } = new List<Author>();
        public Book()
        {

        }
        private bool IsValidIsbn(string isbn)
        {
            if (isbn == null)
            {
                throw new NullReferenceException();
            }
            else if (_isbnWithHyphens.Match(isbn).Success || _isbnDigitsOnly.Match(isbn).Success)
            {
                return true;
            }
            else
            {
                throw new ArgumentException();
            }
            return _isbn != null;
        }
    }
}
