using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.One.ElectronicCatalog.Entities
{
    internal class Catalog : IEnumerable
    {
        List<Book> _books;
        Book _book;
        public Book this[string isbn]
        {
            get
            {
                var books = _books.Where(book => book.Isbn == isbn).Select(book => book).ToList();
                _book = books.FirstOrDefault();

                if (_book != null)
                {
                    return _book;
                }
                throw new KeyNotFoundException();
            }
            set
            {
                isbn = value.Isbn;
                if (value != null)
                {
                    _books.Add(value);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }
        
    }
}
