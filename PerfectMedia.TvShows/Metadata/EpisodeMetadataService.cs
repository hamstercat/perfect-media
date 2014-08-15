using System.Threading.Tasks;
using PerfectMedia.FileInformation;

namespace PerfectMedia.TvShows.Metadata
{
    public class EpisodeMetadataService : IEpisodeMetadataService
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IEpisodeMetadataRepository _metadataRepository;
        private readonly ITvShowMetadataUpdater _metadataUpdater;
        private readonly IFileInformationService _fileInformationService;

        public EpisodeMetadataService(IFileSystemService fileSystemService,
            IEpisodeMetadataRepository metadataRepository,
            ITvShowMetadataUpdater metadataUpdater,
            IFileInformationService fileInformationService)
        {
            _fileSystemService = fileSystemService;
            _metadataRepository = metadataRepository;
            _metadataUpdater = metadataUpdater;
            _fileInformationService = fileInformationService;
        }

        public async Task<EpisodeMetadata> Get(string episodeFile)
        {
            return await _metadataRepository.Get(episodeFile);
        }

        public void Save(string episodeFile, EpisodeMetadata metadata)
        {
            _metadataRepository.Save(episodeFile, metadata);
        }

        public async Task Update(string episodeFile, string serieId)
        {
            EpisodeNumber episode = TvShowHelper.FindEpisodeNumberFromFile(_fileSystemService, episodeFile);
            EpisodeMetadata metadata = await GetMetadata(episodeFile, serieId, episode);
            metadata.FileInformation = _fileInformationService.GetVideoFileInformation(episodeFile);
            Save(episodeFile, metadata);
        }

        public async Task Delete(string episodeFile)
        {
            await _metadataRepository.Delete(episodeFile);
        }

        private async Task<EpisodeMetadata> GetMetadata(string episodeFile, string serieId, EpisodeNumber episode)
        {
            try
            {
                return await _metadataUpdater.GetEpisodeMetadata(serieId, episode.SeasonNumber, episode.EpisodeSeasonNumber);
            }
            catch (ApiException)
            {
                throw new EpisodeNotFoundException(episodeFile);
            }
        }
    }
}
