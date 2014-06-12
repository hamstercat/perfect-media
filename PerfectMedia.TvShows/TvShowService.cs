using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows
{
    public class TvShowService : ITvShowService
    {
        public IEnumerable<Season> GetSeasons(string tvShowPath)
        {
            if(string.IsNullOrEmpty(tvShowPath)) throw new ArgumentNullException("tvShowPath");

            foreach (string seasonFolder in Directory.GetDirectories(tvShowPath, "Season *", SearchOption.TopDirectoryOnly))
            {
                yield return new Season { Path = seasonFolder };
            }
            foreach (string seasonFolder in Directory.GetDirectories(tvShowPath, "Special*", SearchOption.TopDirectoryOnly))
            {
                yield return new Season { Path = seasonFolder };
            }
        }
    }
}
