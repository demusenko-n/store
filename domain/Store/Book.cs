using System.Text.RegularExpressions;

namespace Store
{
    public class Book
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Book(int id, string isbn, string author, string title, string description, decimal price)
        {
            Id = id;
            Isbn = isbn;
            Title = title;
            Author = author;
            Description = description;
            Price = price;
        }
        internal static bool IsIsbn(string? s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }

            s = s.Replace("-", "")
                .Replace(" ", "")
                .ToUpper();

            return Regex.IsMatch(s, @"^ISBN\d{10}(\d{3})?$");
        }
    }
}
