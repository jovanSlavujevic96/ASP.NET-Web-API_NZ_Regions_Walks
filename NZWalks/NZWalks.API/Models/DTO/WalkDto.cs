using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models.DTO
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        required public string Name { get; set; }
        required public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        required public DifficultyDto Difficulty { get; set; }
        required public RegionDto Region { get; set; }
    }

    public class WalkDtoV2
    {
        public Guid Id { get; set; }
        required public string WalkName { get; set; }
        required public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        required public DifficultyDto Difficulty { get; set; }
        required public RegionDto Region { get; set; }
    }
}
