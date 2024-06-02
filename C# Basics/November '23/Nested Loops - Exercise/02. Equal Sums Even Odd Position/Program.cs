using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            for (int i = firstNum; i <= secondNum; i++)
            {
                string curr = i.ToString();
                int evenSum = 0, oddSum = 0;
                for (int j = 0; j < curr.Length; j++)
                {
                    int currentNum = int.Parse(curr[j].ToString());
                    if (j % 2 == 0) { evenSum += currentNum; }
                    else { oddSum += currentNum; }
                }
                if (evenSum == oddSum) { Console.Write(i + " "); }
            }
        }
    }
}