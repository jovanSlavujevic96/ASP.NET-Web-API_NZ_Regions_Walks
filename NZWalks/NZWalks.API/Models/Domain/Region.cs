namespace NZWalks.API.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set; }
        required public string Code { get; set; }
        required public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
