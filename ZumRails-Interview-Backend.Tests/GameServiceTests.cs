using ZumRails_Interview_Backend.Models;
using ZumRails_Interview_Backend.Services;

namespace ZumRails_Interview_Backend.Tests
{
    public class GameServiceTests
    {
        private GameService gameService;

        public GameServiceTests()
        {
            this.gameService = new GameService();
        }

        [Fact]
        public void Battle_AllEqualPokemons_ShouldReturnAllTies()
        {
            Pokemon[] pokemons = new Pokemon[8];
            for (int i = 0; i < pokemons.Length; i++)
            {
                pokemons[i] = new Pokemon { Id = i, Name = "mewtwo", Type = "psychic", BaseExperience = 340 };
            }

            var results = gameService.Battle(pokemons);

            foreach (var result in results)
            {
                Assert.Equal(0, result.Wins);
                Assert.Equal(0, result.Losses);
                Assert.Equal(7, result.Ties);
            }
        }

        [Fact]
        public void Battle_OnlyOneWin_ShouldReturnAllWinnersButOne()
        {
            Pokemon[] pokemons = new Pokemon[8];
            for (int i = 0; i < pokemons.Length - 1; i++)
            {
                pokemons[i] = new Pokemon { Id = i, Name = "mewtwo", Type = "psychic", BaseExperience = 340 };
            }
            pokemons[7] = new Pokemon { Id = 7, Name = "mewtwo", Type = "psychic", BaseExperience = 34 };

            var results = gameService.Battle(pokemons);

            var looser = results.First(p => p.Pokemon.Id == 7);

            Assert.Equal(7, looser.Losses);
            Assert.Equal(0, looser.Wins);
            Assert.Equal(0, looser.Ties);

            foreach (var result in results)
            {
                if (result.Pokemon.Id != 7)
                {
                    Assert.Equal(0, result.Losses);
                    Assert.Equal(1, result.Wins);
                    Assert.Equal(6, result.Ties);
                }
            }
        }
    }
}