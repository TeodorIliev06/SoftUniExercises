namespace _07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int start = 0;
            int len = 1;
            int bestStart = 0;
            int bestLen = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i - 1])
                {
                    len++;
                    if (len > bestLen)
                    {
                        bestLen = len;
                        bestStart = start;
                    }
                }
                else
                {
                    start = i;
                    len = 1;
                }
            }

            int[] final = input.Skip(bestStart).Take(bestLen).ToArray();
            Console.WriteLine(string.Join(" ", final));
        }
    }
}