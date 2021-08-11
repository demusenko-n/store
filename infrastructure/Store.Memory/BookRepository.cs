﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] _books =
        {
            new (1, "ISBN1231231231", "D. Knuth", "Art of Programming"),
            new (2, "ISBN1231231232", "M. Fowler", "Refactoring"),
            new (3, "ISBN1231231233", "B. Kernighan, D. Ritchie", "C Programming Language")
        };

        public IEnumerable<Book> GetAllByIsbn(string isbn)
        {
            return _books.Where(book => book.Isbn.Equals(isbn, StringComparison.CurrentCultureIgnoreCase));
        }

        public IEnumerable<Book> GetAllByTitleOrAuthor(string titleOrAuthorPart)
        {
            return _books.Where(book =>
                book.Title.Contains(titleOrAuthorPart, StringComparison.CurrentCultureIgnoreCase) ||
                book.Author.Contains(titleOrAuthorPart, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}