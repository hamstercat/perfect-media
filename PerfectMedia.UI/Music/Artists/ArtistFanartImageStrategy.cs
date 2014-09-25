using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectMedia.Music;
using PerfectMedia.UI.Images;

namespace PerfectMedia.UI.Music.Artists
{
    public class ArtistFanartImageStrategy : IImageStrategy
    {
        private readonly IMusicImageUpdater _imageUpdater;
        private readonly IArtistViewModel _artistViewModel;

        public ArtistFanartImageStrategy(IMusicImageUpdater imageUpdater, IArtistViewModel artistViewModel)
        {
            _imageUpdater = imageUpdater;
            _artistViewModel = artistViewModel;
        }

        public async Task<IEnumerable<Image>> FindImages()
        {
            IEnumerable<string> images = await _imageUpdater.FindArtistImages(_artistViewModel.Id);
            return images.Select(CreateImageFromUrl);
        }

        private static Image CreateImageFromUrl(string url)
        {
            return new Image
            {
                Url = url,
                WidthRatio = 1920,
                HeightRatio = 1080
            };
        }
    }
}