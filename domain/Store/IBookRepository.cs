using System.Collections;
using System.Collections.Generic;

namespace Store
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllByTitle(string titlePart);
    }
}