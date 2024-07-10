using System.Text;

namespace CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string colour;

        public Car(string model, Engine engine)
        {
            this.model = model;
            this.engine = engine;
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.weight = weight;
        }

        public Car(string model, Engine engine, string info) : this(model, engine)
        {
            if (int.TryParse(info, out int weight))
            {
                this.weight = weight;
            }
            else
            {
                this.colour = info;
            }
        }

        public Car(string model, Engine engine, int weight, string colour) : this(model, engine)
        {
            this.weight = weight;
            this.colour = colour;
        }

        public string Colour
        {
            get { return colour; }
            set { colour = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }


        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public override string ToString()
        {
            StringBuilder output = new();

            output.AppendLine($"{Model}:");
            output.AppendLine($"  {Engine.Model}:");
            output.AppendLine($"    Power: {Engine.Power}");
            output.AppendLine($"    Displacement: {(Engine.Displacement == 0 ? "n/a" : Engine.Displacement.ToString())}");
            output.AppendLine($"    Efficiency: {(Engine.Efficiency == null ? "n/a" : Engine.Efficiency)}");
            output.AppendLine($"  Weight: {(Weight == 0 ? "n/a" : Weight.ToString())}");
            output.AppendLine($"  Color: {(Colour == null ? "n/a" : Colour)}");

            return output.ToString().TrimEnd();
        }
    }
}
