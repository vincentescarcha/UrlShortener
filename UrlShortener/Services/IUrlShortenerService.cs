using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.Services
{
    public interface IUrlShortenerService
    {
        UrlResponse Add(string longUrl);
        bool LongUrlExist(string longUrl);
        UrlResponse GetByUrl(string longUrl);
    }
}
