namespace Vehicles;

public class Car : BaseVehicle
{
    private const double fuelConsumptionIncrease = 0.9;
    public Car(double fuelQuantity, double fuelConsumptionPerKm) 
        : base(fuelQuantity, fuelConsumptionPerKm)
    {
    }

    public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm + fuelConsumptionIncrease;
}
