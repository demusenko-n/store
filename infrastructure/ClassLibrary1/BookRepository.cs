using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books =
        {
            new (1, "Art", "auth"),
            new (2, "Brt", "buth"),
            new (3, "Crt", "cuth"),
            new (4, "Drt", "duth")
        };

        public IEnumerable<Book> GetAllByTitle(string titlePart)
        {
            return books.Where(book => book.Title.Contains(titlePart, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}