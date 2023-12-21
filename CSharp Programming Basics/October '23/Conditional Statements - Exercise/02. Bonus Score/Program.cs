using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = int.Parse(Console.ReadLine());
            double bonus = 0;

            if (score <= 100)
            {
                bonus += 5;
            }
            else if (score > 100 && score <= 1000)
            {
                bonus += 0.2 * score;
            }
            else if (score > 1000)
            {
                bonus = 0.1 * score;
            }
            if (score % 2 == 0)
            {
                bonus += 1;
            }
            if (score % 10 == 5)
            {
                bonus += 2;
            }

            Console.WriteLine(bonus);
            Console.WriteLine(score + bonus);
        }
    }
}