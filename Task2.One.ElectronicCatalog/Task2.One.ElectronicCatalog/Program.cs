using Task2.One.ElectronicCatalog.Entities;
try
{
    var catalog = new Catalog();
    var book1 = new Book("978-1-56619-909-1", "Book111 Title", new HashSet<Author>() { new Author("Sam", "Jones") }, new DateTime(2009, 01, 01));
    var book2 = new Book("978-1-56619-909-2", "Book222 Title", new HashSet<Author>() { new Author("Anna", "Smith") }, new DateTime(2000, 01, 01));
    var book3 = new Book("978-1-56619-909-3", "Book333 Title", new HashSet<Author>() { new Author("Sam", "Jones") }, new DateTime(2010, 01, 01));
    var book4 = new Book("978-1-56619-909-4", "Book444 Title", new HashSet<Author>() { new Author("Sam", "Jones") }, new DateTime(2018, 01, 01));

    catalog["978-1-56619-909-3"] = book3;
    catalog["978-1-56619-909-4"] = book4;
    catalog["978-1-56619-909-1"] = book1;
    catalog["978-1-56619-909-2"] = book2;
    Console.WriteLine(catalog["9781566199093"]);
    //Using catalog obj iterator to order books by title
    foreach (var item in catalog)
    {
        Console.WriteLine(item.Title);
    }
    Console.WriteLine();
    foreach (var item in catalog.GetBooksByAuthor("Sam", "Jones"))
    {
        Console.WriteLine(item.Title);
    }
    Console.WriteLine();
    foreach (var item in catalog.GetBooksByDate())
    {
        Console.WriteLine(item.Date);
    }
    Console.WriteLine();
    foreach (var item in catalog.GetAuthorBooks("Sam", "Jones"))
    {
        Console.WriteLine(item);
    }
    
}
catch (KeyNotFoundException)
{
    Console.WriteLine("The book with specified ISBN was not found.");
}
catch (InvalidOperationException)
{
    Console.WriteLine("You have attempted to assign null");
}
catch (NullReferenceException)
{
    Console.WriteLine("ISBN key does not exist.");
}
catch (ArgumentOutOfRangeException)
{
    Console.WriteLine("Catalog is empty.");
}
catch (ArgumentNullException)
{
    Console.WriteLine("The title of the book is mandatory.");
}
catch (ArgumentException)
{
    Console.WriteLine("Incorrect ISBN format.");
}