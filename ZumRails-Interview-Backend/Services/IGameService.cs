using ZumRails_Interview_Backend.Models;

namespace ZumRails_Interview_Backend.Services
{
    public interface IGameService
    {
        PokemonWithResults[] Battle(Pokemon[] pokemons);
    }
}
