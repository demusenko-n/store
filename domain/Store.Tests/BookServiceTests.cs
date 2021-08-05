using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Store.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn()
        {
            Mock<IBookRepository> bookRepositoryStub = new(MockBehavior.Strict);

            Book bookIsbn = new(1, "ISBN 12312-31231", "D. Knuth", "Art of Programming");
            Book bookTitleOrAuthor = new(2, "ISBN 12312-31232", "M. Fowler", "Refactoring");

            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[]
                {
                    bookIsbn
                });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[]
                {
                    bookTitleOrAuthor
                });

            BookService bookService = new(bookRepositoryStub.Object);

            string validIsbn = "ISBN 12345-67890";
            var actual = bookService.GetAllByQuery(validIsbn);

            Assert.Collection(actual, book => Assert.Equal(book.Id, bookIsbn.Id));
        }

        [Fact]
        public void GetAllByQuery_WithNotIsbn_CallsGetAllByTitleOrAuthor()
        {
            Mock<IBookRepository> bookRepositoryStub = new(MockBehavior.Strict);

            Book bookIsbn = new(1, "ISBN 12312-31231", "D. Knuth", "Art of Programming");
            Book bookTitleOrAuthor = new(2, "ISBN 12312-31232", "M. Fowler", "Refactoring");

            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[]
                {
                    bookIsbn
                });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[]
                {
                    bookTitleOrAuthor
                });

            BookService bookService = new(bookRepositoryStub.Object);

            string author = "Knuth";
            var actual = bookService.GetAllByQuery(author);

            Assert.Collection(actual, book => Assert.Equal(book.Id, bookTitleOrAuthor.Id));
        }
    }
}
