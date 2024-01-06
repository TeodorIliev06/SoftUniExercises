public class Program
{
    public static void Main()
    {
        string fruit = Console.ReadLine().ToLower();
        string day = Console.ReadLine();
        double n = double.Parse(Console.ReadLine());
        double price;

        switch (day)
        {
            case "Monday":
            case "Tuesday":
            case "Wednesday":
            case "Thursday":
            case "Friday":
                if (fruit == "banana")
                {
                    price = 2.5 * n;
                    Console.WriteLine($"{price:F2}");
                }
                if (fruit == "apple") 
                { 
                    price = 1.2 * n;
                    Console.WriteLine($"{price:F2}"); 
                }
                if (fruit == "orange") 
                {
                    price = 0.85 * n;
                    Console.WriteLine($"{price:F2}");
                }
                if (fruit == "grapefruit") 
                {
                    price = 1.45 * n; Console.WriteLine($"{price:F2}");
                }
                if (fruit == "kiwi") 
                { 
                    price = 2.7 * n;
                    Console.WriteLine($"{price:F2}"); 
                }
                if (fruit == "pineapple") 
                {
                    price = 5.5 * n;
                    Console.WriteLine($"{price:F2}");
                }
                if (fruit == "grapes") 
                {
                    price = 3.85 * n;
                    Console.WriteLine($"{price:F2}");
                }
                break;
            case "Saturday":
            case "Sunday":
                if (fruit == "banana") 
                {
                    price = 2.7 * n;
                    Console.WriteLine($"{price:F2}");
                }
                if (fruit == "apple") 
                {
                    price = 1.25 * n;
                    Console.WriteLine($"{price:F2}"); 
                }
                if (fruit == "orange") 
                {
                    price = 0.9 * n; 
                    Console.WriteLine($"{price:F2}");
                }
                if (fruit == "grapefruit") 
                { 
                    price = 1.6 * n; 
                    Console.WriteLine($"{price:F2}");
                }
                if (fruit == "kiwi") 
                {
                    price = 3 * n;
                    Console.WriteLine($"{price:F2}"); 
                }
                if (fruit == "pineapple") 
                { 
                    price = 5.6 * n; 
                    Console.WriteLine($"{price:F2}");
                }
                if (fruit == "grapes") 
                {
                    price = 4.20 * n;
                    Console.WriteLine($"{price:F2}");
                }
                break;
        }
        if ((day != "Monday" && day != "Tuesday" && day != "Wednesday" && day != "Thursday"
            && day != "Friday" && day != "Saturday" && day != "Sunday")
            || (fruit != "banana" && fruit != "apple" && fruit != "orange" &&
            fruit != "kiwi" && fruit != "pineapple" && fruit != "grapes" && fruit != "grapefruit"))
            Console.WriteLine("error"); 
    }
}