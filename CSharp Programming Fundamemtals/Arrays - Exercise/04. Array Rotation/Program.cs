namespace _04._Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var end = arr[0];
                for (var j = 0; j < arr.Length - 1; j++)
                {
                    arr[j] = arr[j + 1];
                }

                arr[arr.Length - 1] = end;
            }

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}