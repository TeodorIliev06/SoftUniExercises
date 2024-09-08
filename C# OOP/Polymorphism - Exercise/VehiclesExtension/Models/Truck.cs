namespace VehiclesExtension;

public class Truck : BaseVehicle
{
    public Truck(double fuelConsumptionPerKm, int tankCapacity)
        : base(fuelConsumptionPerKm, tankCapacity)
    {
    }

    public Truck(double fuelQuantity, double fuelConsumptionPerKm, int tankCapacity)
        : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {
    }
    public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm + 1.6;

    public override void Refuel(double liters)
    {
        if (liters < 1)
        {
            Console.WriteLine("Fuel must be a positive number");
            return;
        }
        else if (FuelQuantity + liters > TankCapacity)
        {
            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            return;
        }
        FuelQuantity += liters * 95 / 100;
    }
}
