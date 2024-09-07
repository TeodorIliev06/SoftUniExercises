namespace Shapes;

public class StartUp
{
    static void Main(string[] args)
    {
        Rectangle rectangle = new Rectangle(3, 4);
        Circle circle = new(3);

        DrawFigure(circle);
        Console.WriteLine();
        DrawFigure(rectangle);
    }

    private static void DrawFigure(Shape shape)
    {
        Console.WriteLine(shape.CalculateArea());
        Console.WriteLine(shape.CalculatePerimeter());
        Console.WriteLine(shape.Draw());
    }
}
