using ZumRails_Interview_Backend.Models;
using ZumRails_Interview_Backend.Services;

namespace ZumRails_Interview_Backend.Tests
{
    public class PokemonResultsSorterTests
    {
        private PokemonResultsSorter pokemonResultsSorter;
        private PokemonWithResults pokemon1WithResults;
        private PokemonWithResults pokemon2WithResults;
        private PokemonWithResults pokemon3WithResults;

        public PokemonResultsSorterTests()
        {
            this.pokemonResultsSorter = new PokemonResultsSorter();
            this.pokemon1WithResults = new PokemonWithResults
            {
                Pokemon = new Pokemon { Id = 0, Name = "B", Type = "Type", BaseExperience = 5 },
                Wins = 2,
                Losses = 0,
                Ties = 2
            };

            this.pokemon2WithResults = new PokemonWithResults
            {
                Pokemon = new Pokemon { Id = 2, Name = "C", Type = "Type", BaseExperience = 5 },
                Wins = 1,
                Losses = 1,
                Ties = 1
            };

            this.pokemon3WithResults = new PokemonWithResults
            {
                Pokemon = new Pokemon { Id = 1, Name = "A", Type = "Type", BaseExperience = 5 },
                Wins = 0,
                Losses = 2,
                Ties = 0
            };
        }

        [Fact]
        public void Sort_ByIdAscending_ShouldReturnSortedByIdAscending()
        {
            var sorted = this.pokemonResultsSorter.Sort(
                [pokemon1WithResults, pokemon2WithResults, pokemon3WithResults],
                Models.Sort.SortType.Id, Models.Sort.SortDirection.Asc).ToArray();

            Assert.Equal(0, sorted[0].Pokemon.Id);
            Assert.Equal(1, sorted[1].Pokemon.Id);
            Assert.Equal(2, sorted[2].Pokemon.Id);
        }

        [Fact]
        public void Sort_ByIdDescending_ShouldReturnSortedByIdDescending()
        {
            var sorted = this.pokemonResultsSorter.Sort(
                [pokemon1WithResults, pokemon2WithResults, pokemon3WithResults],
                Models.Sort.SortType.Id, Models.Sort.SortDirection.Desc).ToArray();

            Assert.Equal(2, sorted[0].Pokemon.Id);
            Assert.Equal(1, sorted[1].Pokemon.Id);
            Assert.Equal(0, sorted[2].Pokemon.Id);
        }

        [Fact]
        public void Sort_ByNameAscending_ShouldReturnSortedByNameAscending()
        {
            var sorted = this.pokemonResultsSorter.Sort(
                [pokemon1WithResults, pokemon2WithResults, pokemon3WithResults],
                Models.Sort.SortType.Name, Models.Sort.SortDirection.Asc).ToArray();

            Assert.Equal("A", sorted[0].Pokemon.Name);
            Assert.Equal("B", sorted[1].Pokemon.Name);
            Assert.Equal("C", sorted[2].Pokemon.Name);
        }

        [Fact]
        public void Sort_ByNameDescending_ShouldReturnSortedByNameDescending()
        {
            var sorted = this.pokemonResultsSorter.Sort(
                [pokemon1WithResults, pokemon2WithResults, pokemon3WithResults],
                Models.Sort.SortType.Name, Models.Sort.SortDirection.Desc).ToArray();

            Assert.Equal("C", sorted[0].Pokemon.Name);
            Assert.Equal("B", sorted[1].Pokemon.Name);
            Assert.Equal("A", sorted[2].Pokemon.Name);
        }

        [Fact]
        public void Sort_ByWinsAscending_ShouldReturnSortedByWinsAscending()
        {
            var sorted = this.pokemonResultsSorter.Sort(
                [pokemon1WithResults, pokemon2WithResults, pokemon3WithResults],
                Models.Sort.SortType.Wins, Models.Sort.SortDirection.Asc).ToArray();

            Assert.Equal(0, sorted[0].Wins);
            Assert.Equal(1, sorted[1].Wins);
            Assert.Equal(2, sorted[2].Wins);
        }

        [Fact]
        public void Sort_ByWinsDescending_ShouldReturnSortedByWinsDescending()
        {
            var sorted = this.pokemonResultsSorter.Sort(
                [pokemon1WithResults, pokemon2WithResults, pokemon3WithResults],
                Models.Sort.SortType.Wins, Models.Sort.SortDirection.Desc).ToArray();

            Assert.Equal(2, sorted[0].Wins);
            Assert.Equal(1, sorted[1].Wins);
            Assert.Equal(0, sorted[2].Wins);
        }

        [Fact]
        public void Sort_ByLossesAscending_ShouldReturnSortedByLossesAscending()
        {
            var sorted = this.pokemonResultsSorter.Sort(
                [pokemon1WithResults, pokemon2WithResults, pokemon3WithResults],
                Models.Sort.SortType.Losses, Models.Sort.SortDirection.Asc).ToArray();

            Assert.Equal(0, sorted[0].Losses);
            Assert.Equal(1, sorted[1].Losses);
            Assert.Equal(2, sorted[2].Losses);
        }

        [Fact]
        public void Sort_ByLossesDescending_ShouldReturnSortedByLossesDescending()
        {
            var sorted = this.pokemonResultsSorter.Sort(
                [pokemon1WithResults, pokemon2WithResults, pokemon3WithResults],
                Models.Sort.SortType.Losses, Models.Sort.SortDirection.Desc).ToArray();

            Assert.Equal(2, sorted[0].Losses);
            Assert.Equal(1, sorted[1].Losses);
            Assert.Equal(0, sorted[2].Losses);
        }

        [Fact]
        public void Sort_ByTiesAscending_ShouldReturnSortedByTiesAscending()
        {
            var sorted = this.pokemonResultsSorter.Sort(
                [pokemon1WithResults, pokemon2WithResults, pokemon3WithResults],
                Models.Sort.SortType.Ties, Models.Sort.SortDirection.Asc).ToArray();

            Assert.Equal(0, sorted[0].Ties);
            Assert.Equal(1, sorted[1].Ties);
            Assert.Equal(2, sorted[2].Ties);
        }

        [Fact]
        public void Sort_ByTiesDescending_ShouldReturnSortedByTiesDescending()
        {
            var sorted = this.pokemonResultsSorter.Sort(
                [pokemon1WithResults, pokemon2WithResults, pokemon3WithResults],
                Models.Sort.SortType.Ties, Models.Sort.SortDirection.Desc).ToArray();

            Assert.Equal(2, sorted[0].Ties);
            Assert.Equal(1, sorted[1].Ties);
            Assert.Equal(0, sorted[2].Ties);
        }
    }
}