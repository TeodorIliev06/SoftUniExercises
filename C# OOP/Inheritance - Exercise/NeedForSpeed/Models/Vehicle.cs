namespace NeedForSpeed.Models;

internal class Vehicle
{
    public Vehicle(int horsePower, double fuel)
    {
        HorsePower = horsePower;
        Fuel = fuel;
    }

    public int HorsePower { get; set; }
    public double Fuel { get; set; }
    public double DefaultFuelConsumption { get; set; }
    public virtual double FuelConsumption => 1.25;

    public virtual void Drive(double km)
    {
        Fuel -= km * FuelConsumption;
    }
}
