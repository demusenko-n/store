using System;

namespace Store
{
    public class Book
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Book(int id, string isbn, string author, string title)
        {
            Id = id;
            Isbn = isbn;
            Title = title;
            Author = author;
        }
        internal static bool IsIsbn(string? query)
        {
            return query.Contains("ISBN ");
        }
    }
}
