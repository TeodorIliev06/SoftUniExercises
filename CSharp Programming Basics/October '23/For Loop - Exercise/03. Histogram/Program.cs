using System;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0;
        double br1 = 0, br2 = 0, br3 = 0, br4 = 0, br5 = 0;
        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            if (num < 200) { br1++; }
            else if (num >= 200 && num < 400) { br2++; }
            else if (num >= 400 && num < 600) { br3++; }
            else if (num >= 600 && num < 800) { br4++; }
            else if (num >= 800) { br5++; }
        }
        p1 = br1 / n * 100; Console.WriteLine($"{p1:F2}%");
        p2 = br2 / n * 100; Console.WriteLine($"{p2:F2}%");
        p3 = br3 / n * 100; Console.WriteLine($"{p3:F2}%");
        p4 = br4 / n * 100; Console.WriteLine($"{p4:F2}%");
        p5 = br5 / n * 100; Console.WriteLine($"{p5:F2}%");
    }
}