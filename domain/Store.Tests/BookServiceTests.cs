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

            Book bookIsbn = new(1, "ISBN1231231231", "D. Knuth", "Art of Programming", "Art of Programming description",
                7.19M);
            Book bookTitleOrAuthor = new(2, "ISBN1231231232", "M. Fowler", "Refactoring", "Refactoring description", 12.45M);

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

            Book bookIsbn = new(1, "ISBN1231231231", "D. Knuth", "Art of Programming", "Art of Programming description",
                7.19M);
            Book bookTitleOrAuthor = new(2, "ISBN1231231232", "M. Fowler", "Refactoring", "Refactoring description", 12.45M);

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
