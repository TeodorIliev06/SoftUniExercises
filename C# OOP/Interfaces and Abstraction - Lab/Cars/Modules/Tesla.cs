using Cars.Interfaces;
using System.Reflection.Emit;
using System.Text;

namespace Cars.Modules;

public class Tesla : ICar, IElectricCar
{
    public Tesla(string model, string color, int battery)
    {
        Battery = battery;
        Model = model;
        Color = color;
    }

    public int Battery { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }

    public string Start() => "Engine start";
    public string Stop() => "Breaaak!";
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"{Color} Tesla {Model} with {Battery} Batteries");
        sb.AppendLine(Start());
        sb.AppendLine(Stop());
        return sb.ToString().TrimEnd();
    }
}
