using ZumRails_Interview_Backend.Models;
using ZumRails_Interview_Backend.Models.Sort;

namespace ZumRails_Interview_Backend.Services
{
    public class PokemonResultsSorter : IPokemonResultsSorter
    {
        public PokemonWithResults[] Sort(PokemonWithResults[] pokemonResults, SortType sortBy, SortDirection sortDirection)
        {
            PokemonWithResults[] sortedResults;

            switch (sortBy)
            {
                case SortType.Id:
                    sortedResults = pokemonResults.OrderBy(p => p.Pokemon.Id).ToArray();
                    break;
                case SortType.Name:
                    sortedResults = pokemonResults.OrderBy(p => p.Pokemon.Name).ToArray();
                    break;
                default:
                    var sortByAsString = sortBy.ToString();
                    sortedResults = pokemonResults.OrderBy(p => p.GetType().GetProperty(sortByAsString).GetValue(p, null))
                             .ToArray();
                    break;
            }

            if (sortDirection == SortDirection.Desc)
            {
                sortedResults = sortedResults.Reverse().ToArray();
            }

            return sortedResults;
        }
    }
}
