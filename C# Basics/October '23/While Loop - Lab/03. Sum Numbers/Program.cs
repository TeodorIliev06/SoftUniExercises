using System;

public class Program
{
    public static void Main()
    {
        int end = int.Parse(Console.ReadLine());
        int number = int.Parse(Console.ReadLine());
        int sum = number;
        while (sum < end)
        {
            number = int.Parse(Console.ReadLine());
            sum += number;
        }
        Console.WriteLine(sum);
    }
}