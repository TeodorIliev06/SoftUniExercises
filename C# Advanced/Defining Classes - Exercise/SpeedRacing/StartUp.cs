namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new();
            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(carInfo[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumptionPerKilometer));
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = commandInfo[1];
                int kilometers = int.Parse(commandInfo[2]);

                Car currCar = cars.Where(c => c.Model == model).First();
                currCar.Drive(kilometers);               
            }

            cars.ForEach(c => Console.WriteLine(c));
        }
    }
}
