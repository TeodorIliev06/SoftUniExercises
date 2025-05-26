namespace Zad_28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Rally name: ");
            string rallyName = Console.ReadLine();

            Console.Write("Rally year: ");
            int rallyYear = int.Parse(Console.ReadLine());

            var rally = new Rally(rallyName, rallyYear);

            Console.WriteLine();
            Console.Write("[a]dd [v]iew [q]uit: ");

            ConsoleKey key;
            while ((key = Console.ReadKey().Key) != ConsoleKey.Q)
            {
                Console.WriteLine();
                switch (key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine("Enter pilot data:");

                        Console.Write("Pilot name: ");
                        var pilotName = Console.ReadLine();

                        Console.Write("Pilot age: ");
                        var pilotAge = int.Parse(Console.ReadLine());

                        Console.Write("Category: ");
                        var category = Console.ReadLine();

                        Console.Write("Car model: ");
                        var carModel = Console.ReadLine();

                        Console.Write("Car power: ");
                        var carPower = int.Parse(Console.ReadLine());

                        var car = new Car(carModel, carPower);

                        rally.AddPilot(new Pilot(pilotName, pilotAge, car, category));
                        break;

                    case ConsoleKey.V:
                        rally.PrintRallyInformation();
                        break;
                }

                Console.WriteLine();
                Console.Write("[a]dd [v]iew [q]uit: ");
            }

            Environment.Exit(0);
        }
    }
}
