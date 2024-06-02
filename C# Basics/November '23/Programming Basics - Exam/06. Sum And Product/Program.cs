using System;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int a, b, c, d;

        for (a = 1; a <= 9; a++)
        {
            for (b = 9; b >= a; b--)
            {
                for (c = 0; c <= 9; c++)
                {
                    for (d = 9; d >= c; d--)
                    {
                        int sum = a + b + c + d;
                        int multiplied = a * b * c * d;

                        if (sum == multiplied && n % 10 == 5)
                        {
                            Console.WriteLine($"{a}{b}{c}{d}");
                            return;
                        }

                        if (multiplied / sum == 3 && n % 3 == 0)
                        {
                            Console.WriteLine($"{d}{c}{b}{a}");
                            return;
                        }
                    }
                }
            }
        }
        Console.WriteLine("Nothing found");
    }
}