using System;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int sum1 = 0, sum2 = 0, finalsum = 0;
        int br = 0;
        for (int i = 1; i <= n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            if (br % 2 == 0)
            {
                sum1 += num;
            }
            else
            {
                sum2 += num;
            }
            br++;
        }
        if (sum1 == sum2) { Console.WriteLine("Yes"); Console.WriteLine($"Sum = {sum1}"); }
        else if (sum1 != sum2)
        {
            if (sum1 > sum2) { finalsum = Math.Abs(sum1 - sum2); Console.WriteLine("No"); Console.WriteLine($"Diff = {finalsum}"); }
            else if (sum1 < sum2) { finalsum = Math.Abs(sum2 - sum1); Console.WriteLine("No"); Console.WriteLine($"Diff = {finalsum}"); }
        }
    }
}