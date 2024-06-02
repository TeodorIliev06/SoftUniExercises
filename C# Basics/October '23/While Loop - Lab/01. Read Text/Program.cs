using System;

public class Program
{
    public static void Main()
    {
        string text = Console.ReadLine();
        while (text != "Stop")
        {
            Console.WriteLine(text);
            text = Console.ReadLine();
        }
    }
}