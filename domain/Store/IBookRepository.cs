using System.Collections.Generic;

namespace Store
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllByIsbn(string isbn);
        IEnumerable<Book> GetAllByTitleOrAuthor(string titleOrAuthorPart);
        Book? GetById(int id);
    }
}