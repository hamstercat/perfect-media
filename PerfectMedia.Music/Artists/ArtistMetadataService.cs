using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectMedia.Music.Artists
{
    public class ArtistMetadataService : IArtistMetadataService
    {
        private readonly IArtistMetadataRepository _metadataRepository;
        private readonly IMusicMetadataUpdater _metadataUpdater;
        private readonly IMusicImageService _imageService;
        private readonly IMusicImageUpdater _imageUpdater;

        public ArtistMetadataService(IArtistMetadataRepository metadataRepository,
            IMusicMetadataUpdater metadataUpdater,
            IMusicImageService imageService,
            IMusicImageUpdater imageUpdater)
        {
            _metadataRepository = metadataRepository;
            _metadataUpdater = metadataUpdater;
            _imageService = imageService;
            _imageUpdater = imageUpdater;
        }

        public async Task<ArtistMetadata> Get(string path)
        {
            return await _metadataRepository.Get(path);
        }

        public async Task Save(string path, ArtistMetadata metadata)
        {
            await _metadataRepository.Save(path, metadata);
        }

        public async Task Update(string path)
        {
            string artistId = await FindArtistId(path);
            ArtistSummary metadata = await _metadataUpdater.GetArtistMetadata(artistId);
            ArtistMetadata artistMetadata = ConvertMetadata(metadata);
            await Save(path, artistMetadata);
            await UpdateImage(path, artistId);
        }

        public async Task Delete(string path)
        {
            await _metadataRepository.Delete(path);
            await _imageService.DeleteArtist(path);
        }

        public async Task<IEnumerable<ArtistSummary>> FindArtists(string name, int page, int pageSize)
        {
            return await _metadataUpdater.FindArtists(name, page, pageSize);
        }

        private async Task<string> FindArtistId(string path)
        {
            ArtistMetadata metadata = await Get(path);
            if (string.IsNullOrEmpty(metadata.Mbid))
            {
                return await FindIdFromArtistName(path, metadata);
            }
            return metadata.Mbid;
        }

        private async Task<string> FindIdFromArtistName(string path, ArtistMetadata artistMetadata)
        {
            string artistName = FindArtistName(path, artistMetadata);
            for (int page = 0; page < int.MaxValue; page++)
            {
                PagedList<ArtistSummary> artists = await _metadataUpdater.FindArtists(artistName, page, MusicHelper.DefaultPageSize);
                ArtistSummary artistSummary = artists.FirstOrDefault();
                if (artistSummary != null)
                {
                    return artistSummary.Id;
                }
                if (!artists.HasMoreResults)
                {
                    break;
                }
            }
            throw new ArtistNotFoundException("Couldn't find artist for path: " + path);
        }

        private static string FindArtistName(string path, ArtistMetadata artistMetadata)
        {
            if (string.IsNullOrEmpty(artistMetadata.Name))
            {
                return MusicHelper.FindArtistNameFromFolder(path);
            }
            return artistMetadata.Name;
        }

        private ArtistMetadata ConvertMetadata(ArtistSummary artist)
        {
            return new ArtistMetadata
            {
                Mbid = artist.Id,
                Name = artist.Name
            };
        }

        private async Task UpdateImage(string path, string artistId)
        {
            IEnumerable<string> images = await _imageUpdater.FindArtistImages(artistId);
            if (images.Any())
            {
                await _imageService.UpdateArtist(path, images.First());
            }
        }
    }
}
