using Microsoft.AspNetCore.Mvc;
using NZWalks.UI.Models.DTO;

namespace NZWalks.UI.Controllers
{
    public class WalksController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public WalksController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            List<WalkDto> response = new List<WalkDto>();

            try
            {
                // Get All Walks from Web API
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync(
                    "https://localhost:7060" /* from NZWalks.API sln -> Properties/launchSettings.json -> "https/applicationUrl" key */
                  + "/api/v1/walks");

                httpResponseMessage.EnsureSuccessStatusCode();

                var regions = await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<WalkDto>>();
                if (regions != null)
                {
                    response.AddRange(regions);
                }

            }
            catch (Exception ex)
            {
                // Log the exception
            }
            return View(response);
        }
    }
}
