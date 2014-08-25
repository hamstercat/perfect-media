using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Music
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
            throw new NotImplementedException();
        }

        public async Task Delete(string path)
        {
            await _metadataRepository.Delete(path);
        }
    }
}
