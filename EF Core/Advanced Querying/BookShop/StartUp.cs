using BookShop.Models.Enums;
using System.Globalization;
using System.Text;

namespace BookShop
{
    using Data;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetBooksReleasedBefore(db, "12-04-1992"));
        }

        //02. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            if (!Enum.TryParse(command, true, out AgeRestriction ageRestriction))
            {
                return default;
            }

            var bookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            var sb = new StringBuilder();
            foreach (var title in bookTitles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        //03. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b =>
                    b.EditionType == EditionType.Gold &&
                    b.Copies < 5000)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    BookId = b.BookId
                })
                .OrderBy(b => b.BookId)
                .ToList();

            var sb = new StringBuilder();
            foreach (var b in books)
            {
                sb.AppendLine(b.BookTitle);
            }

            return sb.ToString().TrimEnd();
        }

        //04. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    BookPrice = b.Price
                })
                .OrderByDescending(b => b.BookPrice)
                .ToList();

            var sb = new StringBuilder();
            foreach (var b in books)
            {
                sb.AppendLine($"{b.BookTitle} - ${b.BookPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //05. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b =>
                    b.ReleaseDate.HasValue &&
                    b.ReleaseDate.Value.Year != year)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    BookId = b.BookId
                })
                .OrderBy(b => b.BookId)
                .ToList();

            var sb = new StringBuilder();
            foreach (var b in books)
            {
                sb.AppendLine(b.BookTitle);
            }

            return sb.ToString().TrimEnd();
        }

        //06. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var booksByCategory = context.BooksCategories
                .Where(bc =>
                    categories.Contains(bc.Category.Name.ToLower()))
                .Select(bc => bc.Book.Title)
                .OrderBy(b => b)
                .ToList();

            var sb = new StringBuilder();
            foreach (var title in booksByCategory)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        //07. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var releaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < releaseDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //08. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToList()
                .OrderBy(a => a);

            var sb = new StringBuilder();
            foreach (var authorNames in authors)
            {
                sb.AppendLine(authorNames);
            }

            return sb.ToString().TrimEnd();
        }

        //09. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var loweredInput = input.ToLower();

            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(loweredInput))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            var sb = new StringBuilder();
            foreach (var titles in books)
            {
                sb.AppendLine(titles);
            }

            return sb.ToString().TrimEnd();
        }

        //10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var loweredInput = input.ToLower();

            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(loweredInput))
                .Select(b => new
                {
                    b.Title,
                    b.BookId,
                    AuthorNames = $"{b.Author.FirstName} {b.Author.LastName}"
                })
                .OrderBy(b => b.BookId)
                .ToList();

            var sb = new StringBuilder();
            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} ({b.AuthorNames})");
            }

            return sb.ToString().TrimEnd();
        }

        //11. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToList();

            return books.Count;
        }

        //12. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    AuthorNames = $"{a.FirstName} {a.LastName}",
                    Copies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.Copies)
                .ToList();

            var sb = new StringBuilder();
            foreach (var a in authors)
            {
                sb.AppendLine($"{a.AuthorNames} - {a.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        //13. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(bc => bc.Book.Copies * bc.Book.Price)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToList();

            var sb = new StringBuilder();
            foreach (var c in categories)
            {
                sb.AppendLine($"{c.Name} ${c.Profit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //14. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    RecentBooks = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Take(3)
                        .Select(bc => new
                        {
                            BookTitle = bc.Book.Title,
                            ReleaseYear = $"{bc.Book.ReleaseDate.Value.Year}"
                        })
                })
                .OrderBy(c => c.Name)
                .ToList();

            var sb = new StringBuilder();
            foreach (var c in categories)
            {
                sb.AppendLine($"--{c.Name}");

                foreach (var b in c.RecentBooks)
                {
                    sb.AppendLine($"{b.BookTitle} ({b.ReleaseYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //15. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            int yearCheck = 2010;
            int increaseValue = 5;

            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < yearCheck)
                .ToList();

            foreach (var b in books)
            {
                b.Price += increaseValue;
            }

            context.SaveChanges();
        }

        //16. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            int requiredCopies = 4200;

            var booksToRemove = context.Books
                .Where(b => b.Copies < requiredCopies)
                .ToList();

            context.RemoveRange(booksToRemove);
            context.SaveChanges();

            return booksToRemove.Count;
        }
    }
}