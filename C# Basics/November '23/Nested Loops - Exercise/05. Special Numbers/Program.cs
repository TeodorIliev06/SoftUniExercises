using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                if (special(i, n))
                {
                    Console.Write(i + " ");
                }
            }
            static bool special(int num, int N)
            {
                string numString = num.ToString();

                foreach (char digitChar in numString)
                {
                    int digit = int.Parse(digitChar.ToString());
                    if (digit == 0 || N % digit != 0)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}