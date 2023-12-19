using System;

public class Program
{
    public static void Main()
    {
        double usd = double.Parse(Console.ReadLine());
        double lev = usd * 1.79549;

        Console.WriteLine(lev);
    }
}