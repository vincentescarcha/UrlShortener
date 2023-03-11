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
            if (!Uri.TryCreate(request.LongUrl, UriKind.Absolute, out var outputUri))
            {
                return BadRequest("URL is invalid");
            }
            if (outputUri.Scheme != Uri.UriSchemeHttp && outputUri.Scheme != Uri.UriSchemeHttps && outputUri.Scheme != Uri.UriSchemeFtp)
            {
                return BadRequest("URL is invalid");
            }

            return new OkObjectResult(request.LongUrl);
        }
        [HttpGet("/url/{code}")]
        public IActionResult GetLongUrl([FromRoute] string code)
        {
            return new OkObjectResult(code);
        }
    }
}
