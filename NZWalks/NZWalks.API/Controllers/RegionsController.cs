using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Controllers
{
    // https://localhost:portnumber/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        // GET ALL REGIONS
        // GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = new List<Region>
            {
                new() {
                    Id = Guid.NewGuid(),
                    Name = "Auckland Regions",
                    Code = "AKL",
                    RegionImageUrl = "https://outthere.kiwi/wp-content/uploads/Auckland-harbour-1024x576.jpg"
                },
                new() {
                    Id = Guid.NewGuid(),
                    Name = "Wellington Regions",
                    Code = "WLG",
                    RegionImageUrl = "https://www.nzonline.org.nz/wp-content/uploads/2024/09/Wellington-city-2000x1334.jpg"
                }
            };

            return Ok(regions);
        }
    }
}
