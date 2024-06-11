namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.Split(", ");
                string direction = input[0];
                string carNumber = input[1];

                switch (direction)
                {
                    case "IN":
                        cars.Add(carNumber);
                        break;

                    case "OUT":
                        cars.Remove(carNumber);
                        break;
                }
            }
            if (cars.Any())
            {
                Console.WriteLine(string.Join("\n", cars));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
