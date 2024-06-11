namespace _06._Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < inputCount; i++)
            {
                names.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join('\n', names));
        }
    }
}
