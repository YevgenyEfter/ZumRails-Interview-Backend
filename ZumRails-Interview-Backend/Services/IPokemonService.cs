using ZumRails_Interview_Backend.Models;

namespace ZumRails_Interview_Backend.Services
{
    public interface IPokemonService
    {
        Task<Pokemon[]> GetRandomPokemons(int numberOfPokemons, int rangeStart, int rangeEnd);
    }
}
