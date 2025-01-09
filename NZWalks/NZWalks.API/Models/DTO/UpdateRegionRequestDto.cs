namespace NZWalks.API.Models.DTO
{
    public class UpdateRegionRequestDto
    {
        required public string Code { get; set; }
        required public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
