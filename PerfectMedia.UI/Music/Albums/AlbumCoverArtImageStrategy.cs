using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectMedia.Music;
using PerfectMedia.UI.Images;

namespace PerfectMedia.UI.Music.Albums
{
    public class AlbumCoverArtImageStrategy : IImageStrategy
    {
        private readonly IMusicImageUpdater _imageUpdater;
        private readonly IAlbumViewModel _albumViewModel;

        public AlbumCoverArtImageStrategy(IMusicImageUpdater imageUpdater, IAlbumViewModel albumViewModel)
        {
            _imageUpdater = imageUpdater;
            _albumViewModel = albumViewModel;
        }

        public async Task<IEnumerable<Image>> FindImages()
        {
            IEnumerable<string> images = await _imageUpdater.FindAlbumImages(_albumViewModel.Id);
            return images.Select(CreateImageFromUrl);
        }

        private static Image CreateImageFromUrl(string url)
        {
            // TODO: set appropriate width/height ratio
            return new Image
            {
                Url = url,
                WidthRatio = 0,
                HeightRatio = 0
            };
        }
    }
}