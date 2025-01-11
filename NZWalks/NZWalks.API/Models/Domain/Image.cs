using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Models.Domain
{
    public class Image
    {
        required public Guid Id{ get; set; }

        [NotMapped]
        public IFormFile File { get; set; }

        required public string FileName { get; set; }
        public string? FileDescription { get; set; }
        required public string FileExtension { get; set; }
        required public long FileSizeInBytes { get; set; }
        required public string FilePath { get; set; }
    }
}
