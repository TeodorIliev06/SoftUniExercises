using System;
using NeedForSpeed.Models.Cars;
using NeedForSpeed.Models.Motorcycles;

namespace NeedForSpeed;

public class StartUp
{
    public static void Main(string[] args)
    {
        string vehicleType = Console.ReadLine();
        int horsePower = int.Parse(Console.ReadLine());
        double fuel = double.Parse(Console.ReadLine());
        double km = double.Parse(Console.ReadLine());

        switch (vehicleType)
        {
            case "Motorcycle":
                Motorcycle motorcycle = new Motorcycle(horsePower, fuel);
                motorcycle.Drive(km);
                Console.WriteLine(motorcycle);
                break;
            case "RaceMotorcycle":
                RaceMotorcycle raceMotorcycle = new RaceMotorcycle(horsePower, fuel);
                raceMotorcycle.Drive(km);
                Console.WriteLine(raceMotorcycle);
                break;
            case "CrossMotorcycle":
                CrossMotorcycle crossMotorcycle = new CrossMotorcycle(horsePower, fuel);
                crossMotorcycle.Drive(km);
                Console.WriteLine(crossMotorcycle);
                break;
            case "Car":
                Car car = new Car(horsePower, fuel);
                car.Drive(km);
                Console.WriteLine(car);
                break;
            case "FamilyCar":
                FamilyCar familyCar = new FamilyCar(horsePower, fuel);
                familyCar.Drive(km);
                Console.WriteLine(familyCar);
                break;
            case "SportCar":
                SportCar sportCar = new SportCar(horsePower, fuel);
                sportCar.Drive(km);
                Console.WriteLine(sportCar);
                break;
        }
    }
}
