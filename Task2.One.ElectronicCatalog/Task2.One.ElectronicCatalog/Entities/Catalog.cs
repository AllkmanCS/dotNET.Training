using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.One.ElectronicCatalog.Entities
{
    public class Catalog : IEnumerable<Book>
    {
        private List<Book> _books = new List<Book>();
        private Book _book;
        public Book this[string isbn]
        {
            get
            {
                var books = _books
                    .Where(book => book.Isbn == isbn)
                    .Select(book => book).ToList();
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
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var item in _books.OrderBy(book => book.Title))
            {
                yield return item;
            }
        }
        public IEnumerable<Book> GetBooksByAuthor(string firstName, string lastName)
        {
            foreach (var item in _books
                .Where(book => book.Authors
                .Any(author => author.FirstName == firstName))
                .OrderBy(book => book.Title))
            {
                yield return item;
            }
        }
        public IEnumerable<Book> GetBooksByDate()
        {
            foreach (var item in _books.OrderBy(book => book.Date).ThenByDescending(d => d.Date))
            {
                yield return item;
            }
        }
        //c.Get a set of two-items tuples of the form "author - the number of his/her books in the catalog".
        public IEnumerable<(bool, int)> GetAuthorBooks(string firstName, string lastName)
        {
            var author = new Author(firstName, lastName);
            return _books
                .GroupBy(b => b.Authors.Any(a => a.Equals(author)), c => c.Title)
                .Select(res => (res.Key, res.Count()));
        }
    }
}
