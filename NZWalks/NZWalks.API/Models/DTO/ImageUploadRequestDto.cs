using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class ImageUploadRequestDto
    {
        [Required]
        required public IFormFile File{ get; set; }
        [Required] 
        required public string FileName { get; set; }
        public string? FileDescription { get; set; }
    }
}
