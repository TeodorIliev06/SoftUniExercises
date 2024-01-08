using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int ctr = int.Parse(Console.ReadLine());
            double priceStudio = 0, priceApartment = 0;
            if (month == "May" || month == "October")
            {
                priceStudio = 50 * ctr;
                priceApartment = 65 * ctr;
                if (ctr > 7 && ctr < 14) { priceStudio *= 0.95; }
                else if (ctr > 14) { priceStudio *= 0.70; priceApartment *= 0.90; }
                Console.WriteLine($"Apartment: {priceApartment:F2} lv.");
                Console.WriteLine($"Studio: {priceStudio:F2} lv.");
            }
            else if (month == "June" || month == "September")
            {
                priceStudio = 75.20 * ctr;
                priceApartment = 68.70 * ctr;
                if (ctr > 14) { priceStudio *= 0.80; priceApartment *= 0.90; }
                Console.WriteLine($"Apartment: {priceApartment:F2} lv.");
                Console.WriteLine($"Studio: {priceStudio:F2} lv.");
            }
            else if (month == "July" || month == "August")
            {
                priceStudio = 76 * ctr;
                priceApartment = 77 * ctr;
                if (ctr > 14) { priceApartment *= 0.90; }
                Console.WriteLine($"Apartment: {priceApartment:F2} lv.");
                Console.WriteLine($"Studio: {priceStudio:F2} lv.");
            }
        }
    }
}
