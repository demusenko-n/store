using System;
using System.Collections;
using System.Collections.Generic;

namespace Store
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetAllByQuery(string query)
        {
            if (Book.IsIsbn(query))
            {
                return _bookRepository.GetAllByIsbn(query);
            }

            return _bookRepository.GetAllByTitleOrAuthor(query);
        }

    }
}