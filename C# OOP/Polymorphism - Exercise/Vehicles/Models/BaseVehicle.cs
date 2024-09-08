namespace Vehicles;

public abstract class BaseVehicle
{
    protected BaseVehicle(double fuelQuantity, double fuelConsumptionPerKm)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public double FuelQuantity { get; protected set; }
    public virtual double FuelConsumptionPerKm { get; protected set; }

    public void Drive(double distance)
    {
        if (FuelQuantity - FuelConsumptionPerKm * distance > 0)
        {
            FuelQuantity -= FuelConsumptionPerKm * distance;
            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }
        else
        {
            Console.WriteLine($"{GetType().Name} needs refueling");
        }
    }

    public virtual void Refuel(double liters) => FuelQuantity += liters;
    public override string ToString() => $"{GetType().Name}: {FuelQuantity:F2}";
}
