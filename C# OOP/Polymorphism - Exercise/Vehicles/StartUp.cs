namespace Vehicles;

public class StartUp
{
    static void Main(string[] args)
    {
        string[] carInfo = ReadStringArr();
        double carFuelQuantity = double.Parse(carInfo[1]);
        double carConsumption = double.Parse(carInfo[2]);
        BaseVehicle car = new Car(carFuelQuantity, carConsumption);

        string[] truckInfo = ReadStringArr();
        double truckFuelQuantity = double.Parse(truckInfo[1]);
        double truckConsumption = double.Parse(truckInfo[2]);
        BaseVehicle truck = new Truck(truckFuelQuantity, truckConsumption);

        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {

            string[] commandTokens = ReadStringArr();
            string command = commandTokens[0];
            string vehicleType = commandTokens[1];
            double distance;
            switch (command)
            {
                case "Drive":
                    distance = double.Parse(commandTokens[2]);
                    if (vehicleType == "Car")
                    {
                        car.Drive(distance);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Drive(distance);
                    }
                    break;
                case "Refuel":
                    double liters = double.Parse(commandTokens[2]);
                    if (vehicleType == "Car")
                    {
                        car.Refuel(liters);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(liters);
                    }
                    break;
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
    }
    private static string[] ReadStringArr()
    {
        return Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }
}
