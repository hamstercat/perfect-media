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

        public ArtistMetadataService(IArtistMetadataRepository metadataRepository, IMusicMetadataUpdater metadataUpdater)
        {
            _metadataRepository = metadataRepository;
            _metadataUpdater = metadataUpdater;
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
        }

        public async Task Delete(string path)
        {
            await _metadataRepository.Delete(path);
        }

        public async Task<IEnumerable<ArtistSummary>> FindArtists(string name)
        {
            return await _metadataUpdater.FindArtists(name);
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
            IEnumerable<ArtistSummary> artistSummaries = await _metadataUpdater.FindArtists(artistName);
            ArtistSummary metadata = artistSummaries.FirstOrDefault();
            if (metadata == null)
            {
                throw new ArtistNotFoundException("Couldn't find artist for path: " + path);
            }
            return metadata.Id;
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
    }
}
