namespace CustomComparator;

public class CustomComparator : IComparer<int>
{
    public int Compare(int x, int y)
    {
        bool xIsEven = x % 2 == 0;
        bool yIsEven = y % 2 == 0;

        return xIsEven
            ? yIsEven ? x.CompareTo(y) : -1  // x even, y odd - -1; x even, y even - compare
            : yIsEven ? 1 : x.CompareTo(y);  // x odd, y even - 1; x odd, y odd - compare
    }
}
