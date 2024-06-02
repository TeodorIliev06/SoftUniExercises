namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double peopleCount = double.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double singlePrice = 0;
            double totalExpenses = 0;

            switch (dayOfWeek)
            {
                case "Friday":
                    switch (groupType)
                    {
                        case "Students": singlePrice = 8.45; break;
                        case "Business": singlePrice = 10.9; break;
                        case "Regular": singlePrice = 15; break;
                    }
                    break;
                case "Saturday":
                    switch (groupType)
                    {
                        case "Students": singlePrice = 9.8; break;
                        case "Business": singlePrice = 15.6; break;
                        case "Regular": singlePrice = 20; break;
                    }
                    break;
                case "Sunday":
                    switch (groupType)
                    {
                        case "Students": singlePrice = 10.46; break;
                        case "Business": singlePrice = 16; break;
                        case "Regular": singlePrice = 22.5; break;
                    }
                    break;
            }
            totalExpenses = singlePrice * peopleCount;

            if (groupType == "Students" && peopleCount >= 30)
            {
                totalExpenses *= 0.85;
            }
            if (groupType == "Business" && peopleCount >= 100)
            {
                totalExpenses = (peopleCount - 10) * singlePrice;
            }
            if (groupType == "Regular" && peopleCount >= 10 && peopleCount <= 20)
            {
                totalExpenses *= 0.95;
            }

            Console.WriteLine($"Total price: {totalExpenses:f2}");
        }
    }
}