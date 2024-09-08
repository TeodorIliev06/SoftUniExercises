namespace VehiclesExtension;

public class StartUp
{
    static void Main(string[] args)
    {
        string[] carInfo = ReadStringArr();
        double carFuelQuantity = double.Parse(carInfo[1]);
        double carConsumption = double.Parse(carInfo[2]);
        int carTankCapacity = int.Parse(carInfo[3]);
        BaseVehicle car = new Car(carFuelQuantity, carConsumption, carTankCapacity);

        if (carTankCapacity < carFuelQuantity)
        {
            car = new Car(carConsumption, carTankCapacity);
        }

        string[] truckInfo = ReadStringArr();
        double truckFuelQuantity = double.Parse(truckInfo[1]);
        double truckConsumption = double.Parse(truckInfo[2]);
        int truckTankCapacity = int.Parse(truckInfo[3]);
        BaseVehicle truck = new Truck(truckFuelQuantity, truckConsumption, truckTankCapacity);

        if (truckTankCapacity < truckFuelQuantity)
        {
            truck = new Truck(truckConsumption, truckTankCapacity);
        }

        string[] busInfo = ReadStringArr();
        double busFuelQuantity = double.Parse(busInfo[1]);
        double busConsumption = double.Parse(busInfo[2]);
        int busTankCapacity = int.Parse(busInfo[3]);
        BaseVehicle bus = new Bus(busFuelQuantity, busConsumption, busTankCapacity);

        if (busTankCapacity < busFuelQuantity)
        {
            bus = new Bus(busConsumption, busTankCapacity);
        }

        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            try
            {
                string[] commandTokens = ReadStringArr();
                string command = commandTokens[0];
                string vehicleType = commandTokens[1];
                double distance;
                switch (command)
                {
                    case "DriveEmpty":
                        distance = double.Parse(commandTokens[2]);
                        ((Bus)bus).DriveEmpty(distance);
                        break;
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
                        else
                        {
                            bus.Drive(distance);
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
                        else
                        {
                            bus.Refuel(liters);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }

    private static string[] ReadStringArr()
    {
        return Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }
}
