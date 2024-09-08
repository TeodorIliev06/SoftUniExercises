namespace VehiclesExtension;

public abstract class BaseVehicle
{
    protected BaseVehicle(double fuelConsumptionPerKm, int tankCapacity)
    {
        FuelQuantity = 0;
        FuelConsumptionPerKm = fuelConsumptionPerKm;
        TankCapacity = tankCapacity;
    }
    protected BaseVehicle(double fuelQuantity, double fuelConsumptionPerKm, int tankCapacity) 
        : this(fuelConsumptionPerKm, tankCapacity)
    {
        FuelQuantity = fuelQuantity;
    }

    public double FuelQuantity { get; protected set; }
    public virtual double FuelConsumptionPerKm { get; protected set; }
    public virtual int TankCapacity { get; protected set; }

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

    public virtual void Refuel(double liters)
    { 
        if(liters < 1)
        {
            Console.WriteLine("Fuel must be a positive number");
            return;
        }
        else if(FuelQuantity + liters > TankCapacity)
        {
            Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            return;
        }
        FuelQuantity += liters;
    }
    public override string ToString() => $"{GetType().Name}: {FuelQuantity:F2}";
}
