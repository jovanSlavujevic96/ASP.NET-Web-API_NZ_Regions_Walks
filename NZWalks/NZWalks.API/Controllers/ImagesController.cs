using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        // POST: /api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);
            if (ModelState.IsValid)
            {
                // User repository to upload image
            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (allowedExtensions.Contains(Path.GetExtension(request.File.FileName)) == false)
            {
                ModelState.AddModelError("File", "Unsupported file extension");
            }

            if (request.File.Length > 10485760 /*10 MB*/)
            {
                ModelState.AddModelError("File", "File size exceeds 10MB, please upload a smaller size file.");
            }
        }
    }
}
