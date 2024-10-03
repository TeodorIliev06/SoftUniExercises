namespace TemplatePattern.Models;

public class Sourdough : Bread
{
    public override void Bake() => Console.WriteLine("Baking the sourdough bread. (20 minutes)");

    public override void MixIngredients() => Console.WriteLine("Gathering ingredients for sourdough bread.");
}
