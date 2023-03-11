using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlShortenerController : ControllerBase
    {
        public UrlShortenerController()
        {

        }

        [HttpPost]
        public IActionResult ShortenURL([FromBody] UrlRequest request)
        {
            return new OkObjectResult(request.LongUrl);
        }
        [HttpGet("/url/{code}")]
        public IActionResult GetLongUrl([FromRoute] string code)
        {
            return new OkObjectResult(code);
        }
    }
}
