namespace IteratorsAndComparators;

public class BookComparator : IComparer<Book>
{
    public int Compare(Book x, Book y)
    {
        int alphabeticalComparison = x.Year.CompareTo(y.Year);

        if (alphabeticalComparison == 0)
        {
            return y.Title.CompareTo(x.Title);
        }

        return alphabeticalComparison;
    }
}
