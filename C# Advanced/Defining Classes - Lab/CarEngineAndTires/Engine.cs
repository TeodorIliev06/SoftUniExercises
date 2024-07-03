namespace CarManufacturer;

public class Engine
{
    private int horsePower;
    private double cubicCapacity;
    public Engine(int horsePower, double cubicCapacity)
    {
        HorsePower = horsePower;
        CubicCapacity = cubicCapacity;
    }

    public int HorsePower
    {
        get { return this.horsePower; }
        set { this.horsePower = value; }
    }

    public double CubicCapacity
    {
        get { return this.cubicCapacity; }
        set { this.cubicCapacity = value; }
    }
}