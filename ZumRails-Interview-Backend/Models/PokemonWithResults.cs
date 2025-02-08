namespace ZumRails_Interview_Backend.Models
{
    public class PokemonWithResults
    {
        public required Pokemon Pokemon { get; set; }

        public int Wins { get; set; }
        
        public int Losses { get; set; }
        
        public int Ties { get; set; }
    }
}
