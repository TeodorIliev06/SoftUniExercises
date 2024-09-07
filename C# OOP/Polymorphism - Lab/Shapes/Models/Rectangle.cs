namespace Shapes;

public class Rectangle : Shape
{
    private double height;
    private double width;

    public Rectangle(double height, double width)
    {
        Height = height;
        Width = width;
    }

    public double Height
    {
        get => height; 
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Enter a possitive number!");
            }
            height = value;
        }
    }

    public double Width
    {
        get => width; 
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Enter a possitive number!");
            }
            width = value;
        }
    }


    public override double CalculateArea() => width * height;

    public override double CalculatePerimeter() => 2 * (width + height);
}
