using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Engine
    {
		private string model;
		private int power;
		private int displacement;
		private string efficiency;

        public Engine(string model, int power)
        {
            this.model = model;
            this.power = power;
        }

		public Engine(string model, int power, int displacement) : this(model, power)
		{
			this.displacement = displacement;
		}

        public Engine(string model, int power, string info) : this(model, power)
        {
            if (int.TryParse(info, out int displacement))
            {
                this.displacement = displacement;
            }
            else
            {
                this.efficiency = info;
            }
        }

        public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
		{
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public string Efficiency
		{
			get { return efficiency; }
			set { efficiency = value; }
		}


		public int Displacement
		{
			get { return displacement; }
			set { displacement = value; }
		}


		public int Power
		{
			get { return power; }
			set { power = value; }
		}


		public string Model
		{
			get { return model; }
			set { model = value; }
		}

	}
}
