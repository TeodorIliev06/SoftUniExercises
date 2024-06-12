namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());
            var chemicals = new SortedSet<string>();

            for (int i = 0; i < inputLines; i++)
            {
                var input = Console.ReadLine().Split();
                for (int chemical = 0; chemical < input.Length; chemical++)
                {
                    chemicals.Add(input[chemical]);
                }
            }
            Console.WriteLine(string.Join(" ", chemicals));
        }
    }
}
