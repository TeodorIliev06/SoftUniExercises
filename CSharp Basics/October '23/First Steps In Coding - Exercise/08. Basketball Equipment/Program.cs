using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int tax = int.Parse(Console.ReadLine());

            double boots = tax * 0.6;
            double suit = boots * 0.8;
            double ball = suit * 0.25;
            double accessories = ball * 0.2;

            double fulltax = tax + boots + suit + ball + accessories;
            Console.WriteLine(fulltax);
        }
    }
}
