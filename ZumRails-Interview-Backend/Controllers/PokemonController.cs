using Microsoft.AspNetCore.Mvc;
using ZumRails_Interview_Backend.DTOs;
using ZumRails_Interview_Backend.Models;
using ZumRails_Interview_Backend.Models.Sort;
using ZumRails_Interview_Backend.Services;

namespace ZumRails_Interview_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PokemonController(IPokemonService pokemonService, IGameService gameService, IPokemonResultsSorter sorter) : ControllerBase
    {
        [HttpGet("tournament/statistics")]
        public async Task<ActionResult> GetStatistics([FromQuery] SortType? sortBy, [FromQuery] SortDirection sortDirection = SortDirection.Desc)
        {
            if (sortBy is null)
            {
                return BadRequest("sortBy parameter is required.");
            }

            var dict = new Dictionary<int, Pokemon>();
            var rand = new Random();
            while (dict.Count < 8)
            {
                var pokemonId = rand.Next(1, 151);
                if (!dict.ContainsKey(pokemonId))
                {
                    dict[pokemonId] = await pokemonService.GetPokemon(pokemonId);
                }
            }

            var pokemonList = dict.Values.ToArray();

            var pokemonsWithResults = gameService.Battle(pokemonList);

            var pokemonResults = pokemonsWithResults.Select(pokemonWithResults => new PokemonResultDto
            {
                Id = pokemonWithResults.Pokemon.Id,
                Name = pokemonWithResults.Pokemon.Name,
                Type = pokemonWithResults.Pokemon.Type,
                Wins = pokemonWithResults.Wins,
                Losses = pokemonWithResults.Losses,
                Ties = pokemonWithResults.Ties
            }).ToArray();

            pokemonResults = sorter.Sort(pokemonResults, (SortType)sortBy, sortDirection);

            return Ok(pokemonResults);
        }
    }
}
