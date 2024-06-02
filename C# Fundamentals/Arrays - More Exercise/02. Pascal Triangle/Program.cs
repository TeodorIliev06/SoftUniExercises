namespace _02._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Can be done using jagged arrays but we haven't learnt those yet (da ne kazhesh che kopiram)
            int lines = int.Parse(Console.ReadLine());
            long[] rows = new long[lines];
            long[] current = new long[lines];
            rows[0] = 1;
            Console.WriteLine(rows[0]);
            for (int row = 1; row < lines; row++)
            {
                for (int i = 0; i <= row; i++)
                {
                    if (i == 0)
                    {
                        current[i] = 0 + rows[i];
                    }
                    else
                    {
                        current[i] = rows[i - 1] + rows[i];
                    }
                    Console.Write($"{current[i]} ");
                }
                for (int j = 0; j < lines; j++)
                {
                    rows[j] = current[j];
                }
                Console.WriteLine();
            }
        }
    }
}