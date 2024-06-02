using System;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int sum1 = 0, sum2 = 0, finalsum = 0;
        int br = 0;
        for (int i = 1; i <= 2 * n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            br++;
            if (br <= n)
            {
                sum1 += num;
            }
            else
            {
                sum2 += num;
            }
        }
        if (sum1 == sum2) { Console.WriteLine($"Yes, sum = {sum1}"); }
        else if (sum1 != sum2)
        {
            if (sum1 > sum2) { finalsum = Math.Abs(sum1 - sum2); Console.WriteLine($"No, diff = {finalsum}"); }
            else if (sum1 < sum2) { finalsum = Math.Abs(sum2 - sum1); Console.WriteLine($"No, diff = {finalsum}"); }
        }
    }
}