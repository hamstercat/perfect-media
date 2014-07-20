using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia
{
    [Equals]
    public class Image
    {
        public string Url { get; set; }
        public double? Rating { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
    }
}
