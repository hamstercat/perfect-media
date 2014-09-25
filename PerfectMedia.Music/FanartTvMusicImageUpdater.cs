﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectMedia.ExternalApi;
using PerfectMedia.Music.Artists;
using PerfectMedia.Music.Images;

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
            string url = string.Format("/v3/music/{0}?api_key={1}", id, MusicHelper.FanartTvApiKey);
            ArtistImagesQuery images = await _restApiService.Get<ArtistImagesQuery>(url);
            return images.ArtistBackground.Select(artistBackground => artistBackground.Url);
        }

        public Task<IEnumerable<string>> FindAlbumImages(string id)
        {
            throw new NotImplementedException();
        }
    }
}
