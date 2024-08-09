namespace AutomotiveRepairShop;

public class Vehicle
{
    public Vehicle(string vIN, int mileage, string damage)
    {
        VIN = vIN;
        Damage = damage;
        Mileage = mileage;
    }

    public string VIN { get; set; }
    public string Damage { get; set; }
    public int Mileage { get; set; }

    public override string ToString()
    {
        return $"Damage: {Damage}, Vehicle: {VIN} ({Mileage} km)";
    }
}
