using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Data
{
    public class UrlData
    {
        public int Id { get; set; }
        public string LongUrl { get; set; }
        public int Hits { get; set; }
    }
}
