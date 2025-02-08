using RestSharp;
using ZumRails_Interview_Backend.DTOs;
using ZumRails_Interview_Backend.Exceptions;
using ZumRails_Interview_Backend.Models;

namespace ZumRails_Interview_Backend.Services
{
    public class PokemonService : IPokemonService
    {
        private RestClient client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
        
        public async Task<Pokemon> GetPokemon(int id)
        {
            var request = new RestRequest(id.ToString(), Method.Get);
            var response = await client.ExecuteAsync<PokemonDto>(request);
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
                throw new FetchPokemonException(id);
            }
        }
    }
}
