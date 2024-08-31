using Cars.Interfaces;
using System.Text;

namespace Cars.Modules;

public class Seat : ICar
{
    public Seat(string model, string color)
    {
        Model = model;
        Color = color;
    }

    public string Model { get; set; }
    public string Color { get; set; }

    public string Start() => "Engine start";
    public string Stop() => "Breaaak!";
    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"{Color} {GetType().Name} {Model}");
        sb.AppendLine(Start());
        sb.AppendLine(Stop());
        return sb.ToString().TrimEnd();
    } 
}
