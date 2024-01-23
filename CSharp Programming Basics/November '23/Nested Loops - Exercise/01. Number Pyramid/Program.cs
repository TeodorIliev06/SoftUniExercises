using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int br = 1;
            bool check = false;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (br > n) { check = true; break; }
                    Console.Write(br + " ");
                    br++;
                }
                if (check) { break; }
                Console.WriteLine();
            }
        }
    }
}