using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Music
{
    public interface IMusicImageService
    {
        IEnumerable<Image> FindImages(string mbid);
    }
}
