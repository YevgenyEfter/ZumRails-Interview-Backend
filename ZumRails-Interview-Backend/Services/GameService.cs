using ZumRails_Interview_Backend.Models;

namespace ZumRails_Interview_Backend.Services
{
    public class GameService : IGameService
    {
        private static readonly Dictionary<string, string> PokemonTypes = new()
        {
            { "water", "fire" },
            { "fire", "grass" },
            { "grass", "electric" },
            { "electric", "water" },
            { "ghost", "psychic" },
            { "psychic", "fighting" },
            { "fighting", "dark" },
            { "dark", "ghost" }
        };

        public PokemonWithResults[] Battle(Pokemon[] pokemons)
        {
            var pokemonsWithResults = pokemons.Select(p => new PokemonWithResults
                {
                    Pokemon = p,
                    Wins = 0,
                    Losses = 0,
                    Ties = 0
                }
            ).ToArray();

            for (int i = 0; i < pokemonsWithResults.Length; i++)
            {
                for (int j = i + 1; j < pokemonsWithResults.Length; j++)
                {
                    Fight(pokemonsWithResults[i], pokemonsWithResults[j]);
                }
            }

            return pokemonsWithResults;
        }

        private void Fight(PokemonWithResults pokemon1, PokemonWithResults pokemon2)
        {
            if (PokemonTypes.ContainsKey(pokemon1.Pokemon.Type) && PokemonTypes[pokemon1.Pokemon.Type] == pokemon2.Pokemon.Type)
            {
                pokemon1.Wins++;
                pokemon2.Losses++;
            }
            else if (PokemonTypes.ContainsKey(pokemon2.Pokemon.Type) && PokemonTypes[pokemon2.Pokemon.Type] == pokemon1.Pokemon.Type)
            {
                pokemon2.Wins++;
                pokemon1.Losses++;
            }
            else if (pokemon1.Pokemon.BaseExperience > pokemon2.Pokemon.BaseExperience)
            {
                pokemon1.Wins++;
                pokemon2.Losses++;
            }
            else if (pokemon2.Pokemon.BaseExperience > pokemon1.Pokemon.BaseExperience)
            {
                pokemon2.Wins++;
                pokemon1.Losses++;
            }
            else
            {
                pokemon1.Ties++;
                pokemon2.Ties++;
            }
        }
    }
}
