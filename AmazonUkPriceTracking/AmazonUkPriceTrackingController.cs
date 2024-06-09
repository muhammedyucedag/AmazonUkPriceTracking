using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using Microsoft.AspNetCore.Mvc;

namespace AmazonUkPriceTracking
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmazonUkPriceTrackingController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAttackonTitanCharacters()
        {
            // From Web
            var url = "https://attackontitan.fandom.com/wiki/List_of_characters/Anime";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            IList<HtmlNode> nodes = doc.QuerySelectorAll("div.characterbox-main")[1]
                .QuerySelectorAll("div.characterbox-container table tbody");

            var data = nodes.Select(node =>
            {
                var name = node.QuerySelector("tr:nth-child(2) th a").InnerText;
                return new
                {
                    name = name,
                    imageUrl = node.QuerySelector("tr td div a img")
                        .GetAttributeValue("data-src",
                            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fpbs.twimg.com%2Fprofile_images%2F716487122224439296%2FHWPluyjs.jpg&f=1&nofb=1"),
                    descriptionUrl = $"https://attackontitan.fandom.com/wiki/{name.Replace(" ", "_")}_(Anime)"
                };
            });
            return Ok(data);
        }
    }
}