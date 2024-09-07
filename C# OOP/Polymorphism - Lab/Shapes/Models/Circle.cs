namespace Shapes;

public class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Radius
    {
        get => radius;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Enter a possitive number!");
            }
            radius = value;
        }
    }

    public override double CalculateArea() => Math.PI * radius * radius;
    public override double CalculatePerimeter() => 2 * radius * Math.PI;
}
