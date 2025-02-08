using ZumRails_Interview_Backend.DTOs;
using ZumRails_Interview_Backend.Models.Sort;

namespace ZumRails_Interview_Backend.Services
{
    public interface IPokemonResultsSorter
    {
        PokemonResultDto[] Sort(PokemonResultDto[] pokemonResults, SortType sortBy, SortDirection sortDirection);
    }
}
