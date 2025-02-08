namespace ZumRails_Interview_Backend.DTOs
{
    public class InternalPokemonType
    {
        public required string Name { get; set; }
        public required string Url { get; set; }
    }

    public class PokemonType
    {
        public required int Slot { get; set; }

        public required InternalPokemonType Type { get; set; }

    }

    public class PokemonDto
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public required PokemonType[] Types { get; set; }

        public required int Base_Experience { get; set; }
    }
}
