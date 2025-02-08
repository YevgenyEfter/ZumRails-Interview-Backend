using ZumRails_Interview_Backend.DTOs;
using ZumRails_Interview_Backend.Models.Sort;

namespace ZumRails_Interview_Backend.Services
{
    public class PokemonResultsSorter : IPokemonResultsSorter
    {
        public PokemonResultDto[] Sort(PokemonResultDto[] pokemonResults, SortType sortBy, SortDirection sortDirection)
        {
            var sortByAsString = sortBy.ToString();
            var sortedResults = pokemonResults.OrderBy(p => p.GetType().GetProperty(sortByAsString).GetValue(p, null))
                             .ToArray();

            if (sortDirection == SortDirection.Desc)
            {
                sortedResults = sortedResults.Reverse().ToArray();
            }

            return sortedResults;
        }
    }
}
