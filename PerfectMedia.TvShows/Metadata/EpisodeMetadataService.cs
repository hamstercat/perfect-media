using PerfectMedia.FileInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public EpisodeMetadata Get(string episodeFile)
        {
            return _metadataRepository.Get(episodeFile);
        }

        public void Save(string episodeFile, EpisodeMetadata metadata)
        {
            _metadataRepository.Save(episodeFile, metadata);
        }

        public void Update(string episodeFile, string serieId)
        {
            EpisodeNumber episode = TvShowHelper.FindEpisodeNumberFromFile(_fileSystemService, episodeFile);
            EpisodeMetadata metadata = GetMetadata(episodeFile, serieId, episode);
            metadata.FileInformation = _fileInformationService.GetVideoFileInformation(episodeFile);
            Save(episodeFile, metadata);
        }

        public void Delete(string episodeFile)
        {
            _metadataRepository.Delete(episodeFile);
        }

        private EpisodeMetadata GetMetadata(string episodeFile, string serieId, EpisodeNumber episode)
        {
            try
            {
                return _metadataUpdater.GetEpisodeMetadata(serieId, episode.SeasonNumber, episode.EpisodeSeasonNumber);
            }
            catch (ApiException)
            {
                throw new EpisodeNotFoundException(episodeFile);
            }
        }
    }
}
