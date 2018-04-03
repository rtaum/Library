using Library.Repository.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Repository.Repositories
{
    public class BooksRepository
    {
        /// <summary>
        /// All available books list
        /// </summary>
        private readonly IEnumerable<Book> AllBooks = new List<Book> {
                    new Book() { Id = 101, Author = "Agatha Christie", Title = "Murder on the Orient Express", PublicationDate = new DateTime(1934, 1, 1) },
                    new Book() { Id = 102, Author = "Lewis Carroll", Title = "Alice's Adventures in Wonderland", PublicationDate = new DateTime(1865, 11, 26) },
                    new Book() { Id = 103, Author = "Jack London", Title = "The Sea-Wolf", PublicationDate = new DateTime(1904, 11, 26) }
                };

        public IEnumerable<Book> GetAllBooks()
        {
            return AllBooks;
        }

        public Book GetBookById(int id)
        {
            return AllBooks.FirstOrDefault(b => b.Id == id);
        }
    }
}
