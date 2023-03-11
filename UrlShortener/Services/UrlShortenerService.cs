using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Data;

namespace UrlShortener.Services
{
    public class UrlShortenerService : IUrlShortenerService
    {
        public static List<UrlData> Urls = new List<UrlData>();
        public UrlResponse Add(string longUrl)
        {
            var urlData = new UrlData()
            {
                Id = Urls.Count + 1,
                LongUrl = longUrl,
            };
            Urls.Add(urlData);

            return new UrlResponse()
            {
                ShortUrl = Encode(urlData.Id)
            };
        }
        private string Encode(int id)
        {
            return WebEncoders.Base64UrlEncode(BitConverter.GetBytes(id));
        }
        private int Decode(string urlCode)
        {
            return BitConverter.ToInt32(WebEncoders.Base64UrlDecode(urlCode));
        }
    }
}
