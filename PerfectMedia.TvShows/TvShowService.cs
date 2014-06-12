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
        private readonly IFileFinder _fileFinder;

        public TvShowService(IFileFinder fileFinder)
        {
            _fileFinder = fileFinder;
        }

        public IEnumerable<Season> GetSeasons(string tvShowPath)
        {
            if(string.IsNullOrEmpty(tvShowPath)) throw new ArgumentNullException("tvShowPath");

            IEnumerable<string> folders = FindSeasonFolders(tvShowPath);
            foreach (string seasonFolder in folders)
            {
                yield return new Season { Path = seasonFolder };
            }
        }

        public IEnumerable<Episode> GetEpisodes(string seasonPath)
        {
            if (string.IsNullOrEmpty(seasonPath)) throw new ArgumentNullException("seasonPath");

            IEnumerable<string> videoFiles = _fileFinder.FindVideoFiles(seasonPath);
            foreach (string episodeFile in videoFiles)
            {
                yield return new Episode { Path = episodeFile };
            }
        }

        private IEnumerable<string> FindSeasonFolders(string tvShowPath)
        {
            IEnumerable<string> normalSeasons = _fileFinder.FindFolders(tvShowPath, "Season *");
            IEnumerable<string> specialSeasons = _fileFinder.FindFolders(tvShowPath, "Special*");
            return normalSeasons.Union(specialSeasons);
        }
    }
}
