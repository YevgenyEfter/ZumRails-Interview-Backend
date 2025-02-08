using ZumRails_Interview_Backend.Models;
using ZumRails_Interview_Backend.Models.Sort;

namespace ZumRails_Interview_Backend.Services
{
    public interface IPokemonResultsSorter
    {
        PokemonWithResults[] Sort(PokemonWithResults[] pokemonResults, SortType sortBy, SortDirection sortDirection);
    }
}
