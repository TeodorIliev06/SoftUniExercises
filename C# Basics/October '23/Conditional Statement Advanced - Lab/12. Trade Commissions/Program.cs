using System;

public class Program
{
    public static void Main()
    {
        string city = Console.ReadLine();
        double commission = double.Parse(Console.ReadLine());

        if (city == "Sofia")
        {
            if (commission >= 0 && commission <= 500) 
            {
                commission = commission * 0.05;
                Console.WriteLine($"{commission:F2}");
            }
            if (commission > 500 && commission <= 1000) 
            {
                commission = commission * 0.07;
                Console.WriteLine($"{commission:F2}");
            }
            if (commission > 1000 && commission <= 10000) 
            {
                commission = commission * 0.08; 
                Console.WriteLine($"{commission:F2}");
            }
            if (commission > 10000) 
            {
                commission = commission * 0.12; 
                Console.WriteLine($"{commission:F2}"); 
            }
        }

        if (city == "Varna")
        {
            if (commission >= 0 && commission <= 500) 
            {
                commission = commission * 0.045;
                Console.WriteLine($"{commission:F2}"); 
            }
            if (commission > 500 && commission <= 1000)
            { 
                commission = commission * 0.075; 
                Console.WriteLine($"{commission:F2}"); 
            }
            if (commission > 1000 && commission <= 10000) 
            { 
                commission = commission * 0.1;
                Console.WriteLine($"{commission:F2}");
            }
            if (commission > 10000) 
            { 
                commission = commission * 0.13;
                Console.WriteLine($"{commission:F2}");
            }
        }

        if (city == "Plovdiv")
        {
            if (commission >= 0 && commission <= 500) 
            {
                commission = commission * 0.055;
                Console.WriteLine($"{commission:F2}"); 
            }
            if (commission > 500 && commission <= 1000) 
            {
                commission = commission * 0.08; 
                Console.WriteLine($"{commission:F2}");
            }
            if (commission > 1000 && commission <= 10000) 
            { 
                commission = commission * 0.12;
                Console.WriteLine($"{commission:F2}"); 
            }
            if (commission > 10000) 
            { 
                commission = commission * 0.145;
                Console.WriteLine($"{commission:F2}"); 
            }
        }

        if ((city != "Sofia" && city != "Varna" && city != "Plovdiv") || commission < 0)
            Console.WriteLine("error");
    }
}