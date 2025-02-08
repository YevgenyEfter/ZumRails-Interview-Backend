using Microsoft.AspNetCore.Mvc;
using ZumRails_Interview_Backend.DTOs;
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

            // The validity of sortBy and sortDirection values is handled by the framework,
            // so no need to check if the value is within the valid range of enum values.

            var randomPokemons = await pokemonService.GetRandomPokemons(8, 1, 151);

            var pokemonsWithResults = gameService.Battle(randomPokemons);

            pokemonsWithResults = sorter.Sort(pokemonsWithResults, (SortType)sortBy, sortDirection);

            // Prepare result DTOs to send to client.
            var pokemonResults = pokemonsWithResults.Select(pokemonWithResults => new PokemonResultDto
            {
                Id = pokemonWithResults.Pokemon.Id,
                Name = pokemonWithResults.Pokemon.Name,
                Type = pokemonWithResults.Pokemon.Type,
                Wins = pokemonWithResults.Wins,
                Losses = pokemonWithResults.Losses,
                Ties = pokemonWithResults.Ties
            });

            return Ok(pokemonResults);
        }
    }
}
