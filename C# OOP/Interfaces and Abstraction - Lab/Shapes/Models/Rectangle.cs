using Shapes.Interfaces;

namespace Shapes.Models;

public class Rectangle : IDrawable
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int Width
    {
        get => width;
        set => width = value;
    }
    public int Height
    {
        get => height;
        set => height = value;
    }

    public void Draw()
    {
        DrawLine(width, '*', '*');
        for (int i = 1; i < height - 1; ++i)
        {
            DrawLine(width, '*', ' ');
        }
        DrawLine(width, '*', '*');
    }
    private void DrawLine(int width, char end, char mid)
    {
        Console.WriteLine(end);
        for (int i = 1; i < width - 1; ++i)
        {
            Console.WriteLine(mid);
        }
        Console.WriteLine(end);
    }
}
