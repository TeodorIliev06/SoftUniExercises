namespace _02._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] arr2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string str in arr2)
            {
                if (arr1.Contains(str))
                {
                    Console.Write(str + " ");
                }
            }
        }
    }
}