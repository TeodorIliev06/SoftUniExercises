namespace VehiclesExtension;

public class Car : BaseVehicle
{
    public Car(double fuelConsumptionPerKm, int tankCapacity) 
        : base(fuelConsumptionPerKm, tankCapacity)
    {
    }

    public Car(double fuelQuantity, double fuelConsumptionPerKm, int tankCapacity)
        : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {
    }
    public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm + 0.9;
}
