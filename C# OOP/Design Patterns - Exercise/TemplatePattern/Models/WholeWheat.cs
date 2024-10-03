namespace TemplatePattern.Models;

public class WholeWheat : Bread
{
    public override void Bake() => Console.WriteLine("Baking the whole wheat bread. (15 minutes)");

    public override void MixIngredients() => Console.WriteLine("Gathering ingredients for whole wheat bread.");
}
