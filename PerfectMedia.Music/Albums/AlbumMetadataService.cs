using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectMedia.Music.Albums
{
    public class AlbumMetadataService : IAlbumMetadataService
    {
        private readonly IMusicMetadataUpdater _metadataUpdater;
        private readonly IAlbumMetadataRepository _metadataRepository;
        private readonly IMusicImageService _imageService;
        private readonly IMusicImageUpdater _imageUpdater;

        public AlbumMetadataService(IMusicMetadataUpdater metadataUpdater,
            IAlbumMetadataRepository metadataRepository,
            IMusicImageService imageService,
            IMusicImageUpdater imageUpdater)
        {
            _metadataUpdater = metadataUpdater;
            _metadataRepository = metadataRepository;
            _imageService = imageService;
            _imageUpdater = imageUpdater;
        }

        public async Task<AlbumMetadata> Get(string path)
        {
            return await _metadataRepository.Get(path);
        }

        public async Task Save(string path, AlbumMetadata metadata)
        {
            await _metadataRepository.Save(path, metadata);
        }

        public async Task Update(string path, string artistId)
        {
            string albumId = await FindAlbumId(path, artistId);
            ReleaseGroup album = await _metadataUpdater.GetAlbum(albumId);
            AlbumMetadata albumMetadata = ConvertMetadata(album);
            await Save(path, albumMetadata);
            await UpdateImage(path, albumId);
        }

        public async Task Delete(string path)
        {
            await _metadataRepository.Delete(path);
            await _imageService.DeleteArtist(path);
        }

        public async Task<IEnumerable<ReleaseGroup>> FindAlbums(string artistId, int page, int pageNumber)
        {
            return await _metadataUpdater.FindAlbums(artistId, page, pageNumber);
        }

        private async Task<string> FindAlbumId(string path, string artistId)
        {
            AlbumMetadata metadata = await Get(path);
            if (string.IsNullOrEmpty(metadata.Mbid))
            {
                return await FindIdFromPath(path, artistId);
            }
            return metadata.Mbid;
        }

        private async Task<string> FindIdFromPath(string path, string artistId)
        {
            for(int page = 0; page < int.MaxValue; page++)
            {
                PagedList<ReleaseGroup> releases = await _metadataUpdater.FindAlbums(artistId, page, MusicHelper.DefaultPageSize);
                Album matchingAlbum = MusicHelper.FindAlbumFromFolder(path);
                string id = MatchAlbumByYear(releases, matchingAlbum) ?? MatchAlbumByTitle(releases, matchingAlbum);
                if (!string.IsNullOrEmpty(id))
                {
                    return id;
                }
                if (!releases.HasMoreResults)
                {
                    break;
                }
            }
            string message = string.Format("Couldn't find album of artist {0} for path: {1}", artistId, path);
            throw new AlbumNotFoundException(message);
        }

        private string MatchAlbumByYear(IEnumerable<ReleaseGroup> releases, Album matchingAlbum)
        {
            List<ReleaseGroup> matches = releases.Where(a => a.Year == matchingAlbum.Year).ToList();
            if (matches.Count == 1)
            {
                return matches[0].Id;
            }
            if (matches.Count > 1)
            {
                return MatchAlbumByTitle(matches, matchingAlbum);
            }
            return null;
        }

        private string MatchAlbumByTitle(IEnumerable<ReleaseGroup> releases, Album matchingAlbum)
        {
            List<ReleaseGroup> matches = releases.Where(a => EqualsIgnoreCase(a, matchingAlbum)).ToList();
            if (matches.Any())
            {
                return matches[0].Id;
            }
            return null;
        }

        private static bool EqualsIgnoreCase(ReleaseGroup release, Album matchingAlbum)
        {
            return string.Equals(release.Title, matchingAlbum.Title, StringComparison.InvariantCultureIgnoreCase);
        }

        private AlbumMetadata ConvertMetadata(ReleaseGroup release)
        {
            return new AlbumMetadata
            {
                Mbid = release.Id,
                Title = release.Title,
                ReleaseDate = release.DateTime,
                Year = release.Year
            };
        }

        private async Task UpdateImage(string path, string albumId)
        {
            IEnumerable<Image> images = await _imageUpdater.FindImages(albumId);
            if (images.Any())
            {
                await _imageService.UpdateAlbum(path, images.First());
            }
        }
    }
}
