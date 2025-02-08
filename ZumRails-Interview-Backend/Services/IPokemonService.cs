using ZumRails_Interview_Backend.Models;

namespace ZumRails_Interview_Backend.Services
{
    public interface IPokemonService
    {
        Task<Pokemon> GetPokemon(int id);
    }
}
