﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Models;
using UrlShortener.Services;

namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlShortenerController : ControllerBase
    {
        private readonly IUrlShortenerService _service;
        public UrlShortenerController(IUrlShortenerService service)
        {
            _service = service;
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

            if (_service.LongUrlExist(request.LongUrl))
            {
                return new OkObjectResult(_service.GetByLongUrl(request.LongUrl));
            }

            var response = _service.Add(request.LongUrl);

            return new OkObjectResult(response);
        }
        [HttpGet("/url/{code}")]
        public IActionResult GetLongUrl([FromRoute] string code)
        {
            if (!_service.ShortUrlExist(code))
            {
                return new NotFoundObjectResult("Url not found");
            }

            var urlData = _service.GetByShortUrl(code);

            return new RedirectResult(urlData);
        }
    }
}
