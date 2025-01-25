using System.ComponentModel.DataAnnotations;

namespace NZWalks.UI.Models.DTO
{
    public class UpdateWalkRequestDto
    {
        required public string Name { get; set; }
        required public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}
