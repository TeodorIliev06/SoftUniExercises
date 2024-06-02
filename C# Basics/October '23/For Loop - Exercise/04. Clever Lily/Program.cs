using System;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double cena = double.Parse(Console.ReadLine());
        int igr = int.Parse(Console.ReadLine());
        int sum = 0, x = 0;
        for (int i = 1; i <= n; i++)
        {
            if (i % 2 != 0)
            {
                sum += igr;
            }
            else if (i % 2 == 0)
            {
                x += 10;
                sum += x - 1;
            }

        }
        if (sum >= cena) { Console.WriteLine($"Yes! {(sum - cena):F2}"); }
        else { Console.WriteLine($"No! {(cena - sum):F2}"); }
    }
}