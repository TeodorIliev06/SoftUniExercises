namespace MergeSort;

internal class StartUp
{
    static void Main(string[] args)
    {
        int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

        MergeSort<int>.Sort(arr);

        Console.WriteLine(string.Join(" ", arr));
    }
}

public class MergeSort<T> where T : IComparable
{
    public static void Sort(T[] arr)
    {
        T[] aux = new T[arr.Length];
        Sort(arr, aux, 0, arr.Length - 1);
    }

    private static void Sort(T[] arr, T[] aux, int lo, int hi)
    {
        if (lo >= hi)
        {
            return;
        }
        int mid = lo + (hi - lo) / 2;
        Sort(arr, aux, lo, mid);
        Sort(arr, aux, mid + 1, hi);
        Merge(arr, aux, lo, mid, hi);
    }

    private static void Merge(T[] arr, T[] aux, int lo, int mid, int hi)
    {
        // Merge check.
        if (arr[mid].CompareTo(arr[mid + 1]) <= 0)
        {
            return;
        }

        // Copy to aux arr.
        Array.Copy(arr, lo, aux, lo, hi - lo + 1);

        int leftIndex = lo;
        int rightIndex = mid + 1;
        for (int i = lo; i <= hi; i++)
        {
            if (leftIndex > mid)
            {
                arr[i] = aux[rightIndex++];
            }
            else if (rightIndex > hi)
            {
                arr[i] = aux[leftIndex++];
            }
            else if (IsLess(aux[leftIndex], aux[rightIndex]))
            {
                arr[i] = aux[leftIndex++];
            }
            else
            {
                arr[i] = aux[rightIndex++];
            }
        }
    }

    private static bool IsLess(T item1, T item2)
    {
        return item1.CompareTo(item2) < 0;
    }
}