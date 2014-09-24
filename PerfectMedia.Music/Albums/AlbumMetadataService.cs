using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Music.Albums
{
    public class AlbumMetadataService : IAlbumMetadataService
    {
        private readonly IMusicMetadataUpdater _metadataUpdater;
        private readonly IAlbumMetadataRepository _metadataRepository;

        public AlbumMetadataService(IMusicMetadataUpdater metadataUpdater, IAlbumMetadataRepository metadataRepository)
        {
            _metadataUpdater = metadataUpdater;
            _metadataRepository = metadataRepository;
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
            Release album = await _metadataUpdater.GetAlbum(albumId);
            AlbumMetadata albumMetadata = ConvertMetadata(album);
            await Save(path, albumMetadata);
        }

        public async Task Delete(string path)
        {
            await _metadataRepository.Delete(path);
        }

        public async Task<IEnumerable<Release>> FindAlbums(string artistId)
        {
            return await _metadataUpdater.FindAlbums(artistId);
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
            IEnumerable<Release> releases = await _metadataUpdater.FindAlbums(artistId);
            Album matchingAlbum = MusicHelper.FindAlbumFromFolder(path);
            string id = MatchAlbumByYear(releases, matchingAlbum) ?? MatchAlbumByTitle(releases, matchingAlbum);
            if (string.IsNullOrEmpty(id))
            {
                string message = string.Format("Couldn't find album of artist {0} for path: {1}", artistId, path);
                throw new AlbumNotFoundException(message);
            }
            return id;
        }

        private string MatchAlbumByYear(IEnumerable<Release> releases, Album matchingAlbum)
        {
            List<Release> matches = releases.Where(a => a.Year == matchingAlbum.Year).ToList();
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

        private string MatchAlbumByTitle(IEnumerable<Release> releases, Album matchingAlbum)
        {
            List<Release> matches = releases.Where(a => EqualsIgnoreCase(a, matchingAlbum)).ToList();
            if (matches.Any())
            {
                return matches[0].Id;
            }
            return null;
        }

        private static bool EqualsIgnoreCase(Release release, Album matchingAlbum)
        {
            return string.Equals(release.Title, matchingAlbum.Title, StringComparison.InvariantCultureIgnoreCase);
        }

        private AlbumMetadata ConvertMetadata(Release release)
        {
            return new AlbumMetadata
            {
                Mbid = release.Id,
                Title = release.Title,
                ReleaseDate = release.DateTime,
                Year = release.Year
            };
        }
    }
}
