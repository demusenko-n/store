using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Store
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetAllByQuery(string? query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return Enumerable.Empty<Book>();
            }

            if (Book.IsIsbn(query))
            {
                return _bookRepository.GetAllByIsbn(query);
            }

            return _bookRepository.GetAllByTitleOrAuthor(query);
        }

    }
}