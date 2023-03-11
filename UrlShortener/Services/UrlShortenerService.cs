using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Data;
using UrlShortener.Models;

namespace UrlShortener.Services
{
    public class UrlShortenerService : IUrlShortenerService
    {
        private readonly ApplicationDbContext _context;
        public UrlShortenerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool LongUrlExist(string longUrl)
        {
            return _context.Urls.Any(x => x.LongUrl == longUrl);
        }
        public UrlResponse GetByUrl(string longUrl)
        {
            var urlData = _context.Urls.FirstOrDefault(x => x.LongUrl == longUrl);

            return new UrlResponse()
            {
                ShortUrl = Encode(urlData.Id)
            };
        }

        public UrlResponse Add(string longUrl)
        {
            var urlData = new UrlData()
            {
                LongUrl = longUrl
            };
            _context.Add(urlData);
            _context.SaveChanges();

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
