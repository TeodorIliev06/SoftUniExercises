using System;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double salary = double.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string site = Console.ReadLine();
            if (site == "Facebook") { salary = salary - 150; }
            if (site == "Instagram") { salary = salary - 100; }
            if (site == "Reddit") { salary = salary - 50; }
            if (salary <= 0) { Console.WriteLine("You have lost your salary."); break; }
        }
        if (salary > 0) { Console.WriteLine(salary); }
    }
}