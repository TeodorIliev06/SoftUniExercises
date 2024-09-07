using System.Text;

namespace Animals.Models;

internal class Cat : Animal
{
    public Cat(string name, string favouriteFood) : base(name, favouriteFood)
    {
    }

    public override string ExplainSelf()
    {
        StringBuilder sb = new();
        sb.AppendLine(base.ExplainSelf());
        sb.AppendLine("MEEOW");
        return sb.ToString().TrimEnd();
    }
}
