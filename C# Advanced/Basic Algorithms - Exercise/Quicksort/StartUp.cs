namespace Quicksort;

internal class StartUp
{
    static void Main(string[] args)
    {
        int[] array = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Quick.Sort(array);

        Console.WriteLine(string.Join(" ", array));
    }
}

public class Quick
{
    public static void Sort<T>(T[] array) where T : IComparable<T>
    {
        Shuffle(array);
        Sort(array, 0, array.Length - 1);
    }

    private static void Sort<T>(T[] array, int lo, int hi) where T : IComparable<T>
    {
        if (lo >= hi)
        {
            return;
        }

        int part = Partition(array, lo, hi);
        Sort(array, lo, part - 1); // Recursively sort the left subarray
        Sort(array, part + 1, hi); // Recursively sort the right subarray
    }

    private static int Partition<T>(T[] array, int lo, int hi) where T : IComparable<T>
    {
        int randomIndex = new Random().Next(lo, hi + 1);
        Swap(array, lo, randomIndex);

        T pivot = array[lo];
        int i = lo;
        int j = hi + 1;

        while (true)
        {
            // Move the left pointer until finding an element greater than or equal to the pivot
            while (IsLess(array[++i], pivot))
            {
                if (i == hi)
                {
                    break;
                }
            }

            // Move the right pointer until finding an element smaller than or equal to the pivot
            while (IsLess(pivot, array[--j]))
            {
                if (j == lo)
                {
                    break;
                }
            }

            if (i >= j)
            {
                break;
            }

            Swap(array, i, j); // Swap elements to maintain the partitioning
        }

        Swap(array, lo, j); // Swap pivot with the element at the partitioning index
        return j;
    }

    private static void Swap<T>(T[] arr, int i, int j) where T : IComparable<T>
    {
        T temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    private static void Shuffle<T>(T[] arr) where T : IComparable<T>
    {
        Random random = new();

        for (int index = 0; index < arr.Length; index++)
        {
            int randomIndex = index + random.Next(0, arr.Length - index);
            Swap(arr, index, randomIndex);
        }
    }

    private static bool IsLess<T>(T item1, T item2) where T : IComparable<T>
    {
        return item1.CompareTo(item2) < 0;
    }
}