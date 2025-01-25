using Microsoft.AspNetCore.Mvc;
using NZWalks.UI.Models;
using NZWalks.UI.Models.DTO;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace NZWalks.UI.Controllers
{
    public class WalksController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public WalksController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
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

                var walks = await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<WalkDto>>();
                if (walks != null)
                {
                    response.AddRange(walks);
                }

            }
            catch (Exception /*ex*/)
            {
                // Log the exception
            }
            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddWalkViewModel model)
        {
            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage(){
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7060" /* from NZWalks.API sln -> Properties/launchSettings.json -> "https/applicationUrl" key */
                                     + "/api/v1/walks"),
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<WalkDto>();
            if (response is not null)
            {
                return RedirectToAction("Index", "Walks");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = httpClientFactory.CreateClient();

            var response = await client.GetFromJsonAsync<WalkDto>(
                "https://localhost:7060" /* from NZWalks.API sln -> Properties/launchSettings.json -> "https/applicationUrl" key */
              + $"/api/v1/walks/{id}");

            if (response is not null)
            {
                return View(response);
            }
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WalkDto request)
        {
            var updateWalkRequest = new UpdateWalkRequestDto()
            {
                Name = request.Name,
                Description = request.Description,
                LengthInKm = request.LengthInKm,
                WalkImageUrl = request.WalkImageUrl,
                DifficultyId = request.Difficulty.Id,
                RegionId = request.Region.Id
            };

            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri("https://localhost:7060" + $"/api/v1/walks/{request.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(updateWalkRequest), Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<WalkDto>();
            if (response is not null)
            {
                return RedirectToAction("Edit", "Walks");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RegionDto request)
        {
            try
            {
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.DeleteAsync("https://localhost:7060" + $"/api/v1/walks/{request.Id}");
                httpResponseMessage.EnsureSuccessStatusCode();

                return RedirectToAction("Index", "Walks");
            }
            catch (Exception /*ex*/)
            {
                // Log the exception
            }

            return View("Edit");
        }
    }
}
