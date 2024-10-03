using TemplatePattern.Models;

namespace TemplatePattern;

public class Program
{
    static void Main(string[] args)
    {
        Sourdough sourdough = new();
        sourdough.Make();
        Console.WriteLine();

        TwelveGrain twelveGrain = new();
        twelveGrain.Make();
        Console.WriteLine();

        WholeWheat wholeWheat = new();
        wholeWheat.Make();
        Console.WriteLine();
    }
}
