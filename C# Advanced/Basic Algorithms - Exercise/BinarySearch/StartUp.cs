namespace BinarySearch
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int keyIndex = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch.IterativeBinarySearch(arr, keyIndex));
            Console.WriteLine(BinarySearch.RecursiveBinarySearch(arr, keyIndex));
        }
    }

    public class BinarySearch
    {
        //Trying encapsulation
        public static int IterativeBinarySearch(int[] arr, int keyIndex)
        {
            return IterativeBinarySearch(arr, keyIndex, 0, arr.Length - 1);
        }

        private static int IterativeBinarySearch(int[] arr, int key, int lo, int hi)
        {
            lo = 0;
            hi = arr.Length - 1;

            while (lo <= hi)
            {

                int mid = lo + (hi - lo) / 2;

                if (arr[mid] == key)
                {
                    return mid; // Key found at mid
                }
                else if (key < arr[mid])
                {
                    hi = mid - 1; // Search right half
                }
                else
                {
                    lo = mid + 1; // Search left half
                }
            }

            return -1; // Key index not found
        }

        public static int RecursiveBinarySearch(int[] arr, int keyIndex)
        {
            return RecursiveBinarySearch(arr, keyIndex, 0, arr.Length - 1);
        }

        private static int RecursiveBinarySearch(int[] arr, int keyIndex, int lo, int hi)
        {
            if (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (arr[mid] == keyIndex)
                {
                    return mid; // Key found at mid
                }
                else if (arr[mid] < keyIndex)
                {
                    return RecursiveBinarySearch(arr, keyIndex, mid + 1, hi); // Search right half
                }
                else
                {
                    return RecursiveBinarySearch(arr, keyIndex, lo, mid - 1); // Search left half
                }
            }

            return -1; // Key index not found
        }
    }
}