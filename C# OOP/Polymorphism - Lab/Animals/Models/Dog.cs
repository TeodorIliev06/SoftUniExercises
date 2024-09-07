using System.Text;

namespace Animals.Models
{
    internal class Dog : Animal
    {
        public Dog(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            StringBuilder sb = new();
            sb.AppendLine(base.ExplainSelf());
            sb.AppendLine("DJAAF");
            return sb.ToString().TrimEnd();
        }
    }
}
