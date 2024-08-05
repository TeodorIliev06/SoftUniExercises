namespace CustomComparator;

public class StartUp
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Array.Sort(numbers, new CustomComparator());

        Console.WriteLine(string.Join(" ", numbers));
    }
}
