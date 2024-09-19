namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        required public string Name { get; set; }
        required public string Description{ get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        // Navigation properties
        required public Difficulty Difficulty { get; set; }
        required public Region Region { get; set; }
    }
}
