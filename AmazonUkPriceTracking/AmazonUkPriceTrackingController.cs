using Microsoft.AspNetCore.Mvc;

namespace AmazonUkPriceTracking
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmazonUkPriceTrackingController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var url = "https://attackontitan.fandom.com/wiki/List_of_characters/Anime";
            var client = new HttpClient();
            var html = await client.GetStringAsync(url);
            return Ok(html);
        }
    }
}