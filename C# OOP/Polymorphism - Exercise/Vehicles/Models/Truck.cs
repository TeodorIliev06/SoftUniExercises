namespace Vehicles;

public class Truck : BaseVehicle
{
    private const double fuelConsumptionIncrease = 1.6;
    public Truck(double fuelQuantity, double fuelConsumptionPerKm) 
        : base(fuelQuantity, fuelConsumptionPerKm)
    {
    }

    public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm + fuelConsumptionIncrease;

    public override void Refuel(double liters)
    {       
        FuelQuantity += liters * 95 / 100;
    }
}
