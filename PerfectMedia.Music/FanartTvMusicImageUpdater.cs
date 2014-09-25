using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectMedia.ExternalApi;

namespace PerfectMedia.Music
{
    public class FanartTvMusicImageUpdater : IMusicImageUpdater
    {
        private readonly IRestApiService _restApiService;

        public FanartTvMusicImageUpdater(IRestApiService restApiService)
        {
            _restApiService = restApiService;
        }

        public async Task<IEnumerable<string>> FindArtistImages(string id)
        {
            string url = string.Format("/v3/music/{0}?{1}", id, MusicHelper.FanartTvApiKey);
            var images = await _restApiService.Get(url);
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> FindAlbumImages(string id)
        {
            throw new NotImplementedException();
        }
    }
}
