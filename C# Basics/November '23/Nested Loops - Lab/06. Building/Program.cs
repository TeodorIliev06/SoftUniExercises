using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int etazh = int.Parse(Console.ReadLine());
            int staiNaEtazh = int.Parse(Console.ReadLine());

            for (int i = etazh; i >= 1; i--)
            {
                for (int j = 0; j < staiNaEtazh; j++)
                {
                    if (i == etazh && staiNaEtazh >= 1)
                    {
                        Console.Write($"L{i}{j} ");
                    }
                    else if (i % 2 == 0)
                    {
                        Console.Write($"O{i}{j} ");
                    }
                    else
                    {
                        Console.Write($"A{i}{j} ");
                    }
                }

                Console.WriteLine();
            }

        }
    }
}