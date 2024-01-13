using System;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int sum = 0, max = -10000;
        for (int i = 1; i <= n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            if (num > max)
            {
                max = num;
            }
            sum += num;
        }
        if (max == (sum - max)) { Console.WriteLine("Yes"); Console.WriteLine($"Sum = {max}"); }
        else
        {
            int diff = Math.Abs(max - (sum - max));
            Console.WriteLine("No");
            Console.WriteLine($"Diff = {diff}");
        }
    }
}