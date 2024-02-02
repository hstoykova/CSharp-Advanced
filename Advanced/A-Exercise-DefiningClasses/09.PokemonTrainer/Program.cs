namespace _09.PokemonTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;

            Dictionary<string, Trainer> trainers = new();

            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] splitCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = splitCommand[0];
                string pokemonName = splitCommand[1];
                string pokemonElement = splitCommand[2];
                int pokemonHealth = int.Parse(splitCommand[3]);

                Pokemon pokemon = new(pokemonName, pokemonElement, pokemonHealth);

                if (trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName].Pokemons.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainerName, trainer);
                }

            }

            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers.Values.ToList())
                {
                    if (trainer.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(p => p.Health -= 10);
                        trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();

                    }
                }
            }

            foreach (var item in trainers.Values.OrderByDescending(n => n.NumberOfBadges))
            {
                
                Console.WriteLine($"{item.Name} {item.NumberOfBadges} {item.Pokemons.Count}");
            }
        }
    }
}