using System.Linq;
using System.Text.RegularExpressions;

namespace _02._From_Left_to_The_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int spaceIndex = input.IndexOf(' ');
                if (spaceIndex != -1)
                {
                    string leftNumberStr = input.Substring(0, spaceIndex);
                    string rightNumberStr = input.Substring(spaceIndex + 1);

                    long leftSum = 0;
                    long rightSum = 0;

                    foreach (char digit in leftNumberStr)
                    {
                        if (char.IsDigit(digit))
                        {
                            leftSum += digit - '0';
                        }
                    }

                    foreach (char digit in rightNumberStr)
                    {
                        if (char.IsDigit(digit))
                        {
                            rightSum += digit - '0';
                        }
                    }

                    long leftNumber = long.Parse(leftNumberStr);
                    long rightNumber = long.Parse(rightNumberStr);

                    if (leftNumber > rightNumber)
                    {
                        Console.WriteLine(leftSum);
                    }
                    else
                    {
                        Console.WriteLine(rightSum);
                    }
                }
            }
        }
    }
}