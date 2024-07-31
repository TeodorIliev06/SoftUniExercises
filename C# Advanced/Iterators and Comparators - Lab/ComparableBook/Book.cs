namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors.ToList();
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }

        public int CompareTo(Book? other)
        {
            if (Year.CompareTo(other.Year) == 0)
            {
                return Title.CompareTo(other.Title);
            }
            return Year.CompareTo(other.Year);
        }

        public override string ToString()
        {
            return $"{Title} - {Year}".ToString();
        }
    }
}
