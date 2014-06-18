using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Metadata.TheTvDbDataContracts
{
    public class Banner
    {
        public string BannerPath { get; set; }
        public string BannerType { get; set; }
        public double? Rating { get; set; }
        public string Language { get; set; }
        public string Season { get; set; }
    }
}
