namespace VehiclesExtension;

public class Bus : BaseVehicle
{
    public Bus(double fuelConsumptionPerKm, int tankCapacity)
        : base(fuelConsumptionPerKm, tankCapacity)
    {
    }

    public Bus(double fuelQuantity, double fuelConsumptionPerKm, int tankCapacity)
        : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {
    }

    public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm + 1.4;
    public void DriveEmpty(double distance)
    {
        //We reduce the fuel consumption only for the empty rides
        if (FuelQuantity - (FuelConsumptionPerKm-1.4) * distance > 0)
        {
            FuelQuantity -= (FuelConsumptionPerKm-1.4) * distance;
            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }
        else
        {
            Console.WriteLine($"{GetType().Name} needs refueling");
        }

    }
}
