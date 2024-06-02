using System;

public class Program
{
    public static void Main()
    {
        string name = Console.ReadLine();
        double salary = double.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        double suma = salary;

        for (int i = 0; i < n; i++)
        {
            string namejuri = Console.ReadLine();
            double points = double.Parse(Console.ReadLine());

            double tochki = (namejuri.Length * points) / 2;
            suma += tochki;
            if (suma > 1250.5)
            {
                Console.WriteLine($"Congratulations, {name} got a nominee for leading role with {suma:F1}!");
                break;
            }
        }
        if (suma <= 1250.5)
        {
            Console.WriteLine($"Sorry, {name} you need {(1250.5 - suma):F1} more!");
        }
    }
}