using RestSharp;
using ZumRails_Interview_Backend.DTOs;
using ZumRails_Interview_Backend.Exceptions;
using ZumRails_Interview_Backend.Models;

namespace ZumRails_Interview_Backend.Services
{
    public class PokemonService(RestClient restClient) : IPokemonService
    {
        public async Task<Pokemon[]> GetRandomPokemons(int numberOfPokemons, int rangeStart, int rangeEnd)
        {
            var dict = new Dictionary<int, Pokemon>();
            var rand = new Random();
            while (dict.Count < numberOfPokemons)
            {
                var pokemonId = rand.Next(rangeStart, rangeEnd);
                if (!dict.ContainsKey(pokemonId))
                {
                    dict[pokemonId] = await this.GetPokemon(pokemonId);
                }
            }

            return dict.Values.ToArray();
        }

        private async Task<Pokemon> GetPokemon(int id)
        {
            var request = new RestRequest(id.ToString(), Method.Get);
            var response = await restClient.ExecuteAsync<PokemonDto>(request);
            if (response.IsSuccessful && response.Data is not null)
            {
                return new Pokemon
                {
                    Id = response.Data.Id,
                    Name = response.Data.Name,
                    Type = response.Data.Types[0].Type.Name,
                    BaseExperience = response.Data.Base_Experience
                };
            }
            else
            {
                throw new FetchPokemonFailureException(id);
            }
        }
    }
}
