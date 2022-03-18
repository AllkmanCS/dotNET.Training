using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Task2.One.ElectronicCatalog.Entities;

namespace ElectronicCatalogTests
{
    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        public void TestIfDifferentIsbnFormatPointToTheSameObject()
        {
            //arrange
            var catalog = new Catalog();
            var book1 = new Book(
                "978-1-56619-909-1",
                "Book111 Title",
                new HashSet<Author>() { new Author("Sam", "Jones") },
                new DateTime(2009, 01, 01));

            //act
            var testBook = catalog["9781566199091"] = book1;

            //assert
            Assert.AreSame(book1, testBook);
        }
    }
}