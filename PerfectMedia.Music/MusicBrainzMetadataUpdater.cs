using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using PerfectMedia.ExternalApi;
using PerfectMedia.Music.Albums;
using PerfectMedia.Music.Artists;

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
                return string.Format("perfect-media/{0} +https://github.com/hamstercat/perfect-media", version);
            }
        }

        public MusicBrainzMetadataUpdater(IRestApiService restApiService)
        {
            _restApiService = restApiService;
            _restApiService.SetHeader("Accept", "application/json");
            _restApiService.SetHeader("User-Agent", UserAgent);
            _restApiService.SetRateLimiter(1);
        }

        public async Task<IEnumerable<ArtistSummary>> FindArtists(string name)
        {
            string url = string.Format("/ws/2/artist?query={0}", HttpUtility.HtmlEncode(name));
            ArtistQueryMetadata metadata = await _restApiService.Get<ArtistQueryMetadata>(url);
            return metadata.ArtistList;
        }

        public async Task<ArtistSummary> GetArtistMetadata(string artistId)
        {
            string url = string.Format("/ws/2/artist/{0}?inc=tags", artistId);
            ArtistSummary metadata = await _restApiService.Get<ArtistSummary>(url);
            metadata.Id = artistId;
            return metadata;
        }

        public Task<IEnumerable<AlbumSummary>> FindAlbums(string artistId)
        {
            throw new NotImplementedException();
        }

        public Task<AlbumSummary> GetAlbum(string albumId)
        {
            throw new NotImplementedException();
        }
    }
}
