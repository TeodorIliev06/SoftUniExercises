namespace NeedForSpeed.Models.Motorcycles;

internal class Motorcycle : Vehicle
{
    public Motorcycle(int horsePower, double fuel) : base(horsePower, fuel)
    {
        HorsePower = horsePower;
        Fuel = fuel;
    }

    public int HorsePower { get; set; }
    public double Fuel { get; set; }
    public double DefaultFuelConsumption { get; set; }
    public override double FuelConsumption => 1.25;

    public override void Drive(double km)
    {
        Fuel -= km * FuelConsumption;
    }
}
