using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Music
{
    public interface IMusicImageUpdater
    {
        Task<IEnumerable<Image>> FindImages(string id);
    }
}
