namespace _01._Recursive_Array_Sum;

internal class StartUp
{
    static void Main(string[] args)
    {
        int[] array = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Console.WriteLine(GetArraySum(array, 0));
    }

    private static int GetArraySum(int[] array, int index)
    {
        if (index == array.Length)
        {
            return 0;
        }

        return array[index] + GetArraySum(array, index + 1);
    }
}
