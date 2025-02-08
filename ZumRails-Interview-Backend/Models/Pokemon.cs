namespace ZumRails_Interview_Backend.Models
{
    public class Pokemon
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public required string Type { get; set; }

        public required int BaseExperience { get; set; }
    }
}
