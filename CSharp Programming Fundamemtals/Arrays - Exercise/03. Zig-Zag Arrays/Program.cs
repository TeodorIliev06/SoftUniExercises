namespace _03._Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[] arr1 = new int[num];
            int[] arr2 = new int[num];

            for (int i = 0; i < num; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    arr1[i] = input[0];
                    arr2[i] = input[1];
                }
                else
                {
                    arr2[i] = input[0];
                    arr1[i] = input[1];
                }
            }

            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2));
        }
    }
}