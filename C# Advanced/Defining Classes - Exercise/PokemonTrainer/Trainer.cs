using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    public class Trainer
    {
		private string name;
		private int badges;
		private List<Pokemon> pokemons = new();

        public Trainer(string name)
        {
            this.name = name;
            this.badges = 0;
            this.pokemons = new List<Pokemon>();
        }

        public Trainer(string name, List<Pokemon> pokemons)
        {
            this.name = name;
            this.badges = 0;
            this.pokemons = pokemons;
        }

        public List<Pokemon> Pokemon
		{
			get { return pokemons; }
			set { pokemons = value; }
		}

		public int Badges
		{
			get { return badges; }
			set { badges = value; }
		}


		public string Name
		{
			get { return name; }
			set { name = value; }
		}

        public override string ToString()
        {
            return $"{Name} {Badges} {Pokemon.Count}";
        }
    }
}
