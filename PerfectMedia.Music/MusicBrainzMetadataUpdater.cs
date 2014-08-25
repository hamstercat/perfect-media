using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PerfectMedia.Music
{
    public class MusicBrainzMetadataUpdater : IMusicMetadataUpdater
    {
        private readonly IRestApiService _restApiService;

        private static string UserAgent
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fileVersionInfo.FileVersion;
                return string.Format("perfect-media/v{0} (https://github.com/hamstercat/perfect-media)", version);
            }
        }

        public MusicBrainzMetadataUpdater(IRestApiService restApiService)
        {
            _restApiService = restApiService;
            _restApiService.SetHeader("Accept", "application/json");
            _restApiService.SetHeader("User-Agent", UserAgent);
        }

        public async Task<IEnumerable<ArtistSummary>> FindArtists(string name)
        {
            string url = string.Format("/ws/2/artist?query={0}", HttpUtility.HtmlEncode(name));
            return await _restApiService.Get<List<ArtistSummary>>(url);
        }
    }
}
