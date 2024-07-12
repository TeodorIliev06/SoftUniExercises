using System.Collections.Generic;

namespace PokemonTrainer
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new();
            string input;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);               
                AddPokemonToTrainer(trainers, trainerName, pokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemon.Any(p => p.Element == input))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        ReducePokemonHealth(trainer);
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.Badges).ThenBy(t => trainers.IndexOf(t)))
            {
                Console.WriteLine(trainer);
            }
        }

        private static void AddPokemonToTrainer(List<Trainer> trainers, string trainerName, Pokemon pokemon)
        {
            // Check if the trainer already exists
            Trainer existingTrainer = trainers.FirstOrDefault(t => t.Name == trainerName);
            if (existingTrainer != null)
            {
                existingTrainer.Pokemon.Add(pokemon);
            }
            else
            {
                Trainer newTrainer = new Trainer(trainerName);
                newTrainer.Pokemon.Add(pokemon);
                trainers.Add(newTrainer);
            }
        }

        private static void ReducePokemonHealth(Trainer trainer)
        {
            foreach (var pokemon in trainer.Pokemon.ToList())
            {
                pokemon.Health -= 10;
                if (pokemon.Health <= 0)
                {
                    trainer.Pokemon.Remove(pokemon);
                }
            }
        }
    }
}
