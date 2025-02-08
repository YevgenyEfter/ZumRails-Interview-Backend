namespace ZumRails_Interview_Backend.DTOs
{
    public class PokemonResultDto
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public required string Type { get; set; }

        public required int Wins { get; set; }

        public required int Losses { get; set; }

        public required int Ties { get; set; }
    }
}
