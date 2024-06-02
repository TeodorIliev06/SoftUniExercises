using System;

public class Program
{
    public static void Main()
    {
        int pages = int.Parse(Console.ReadLine());
        int pace = int.Parse(Console.ReadLine());
        int days = int.Parse(Console.ReadLine());

        int hours = pages / pace;
        int dailyhours = hours / days;

        Console.WriteLine(dailyhours);
    }
}