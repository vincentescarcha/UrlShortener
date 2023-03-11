using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Services
{
    public interface IUrlShortenerService
    {
        UrlResponse Add(string longUrl);
    }
}
