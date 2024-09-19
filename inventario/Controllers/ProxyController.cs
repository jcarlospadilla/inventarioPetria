using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace inventario.Controllers
{
    //api/proxy/google-drive
    [ApiController]
    [Route("api/[controller]")]
    public class ProxyController: ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProxyController> _logger;

        public ProxyController(HttpClient httpClient, ILogger<ProxyController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _logger.LogInformation("ProxyController loaded successfully.");
        }

        [HttpGet("google-drive")]
        public async Task<IActionResult> GetGoogleDriveData()
        {
            // The Google Drive direct download link
            var googleDriveUrl = "https://drive.google.com/uc?export=download&id=1mj2EwdkUYaBnVK5uIBCS290prnxjrcfV";

            try
            {
                // Fetch the data from Google Drive
                var result = await _httpClient.GetStringAsync(googleDriveUrl);
                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error fetching data: {ex.Message}");
            }
        }
    }
}
