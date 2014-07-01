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
        private readonly IEpisodeMetadataRepository _metadataRepository;
        private readonly ITvShowMetadataUpdater _metadataUpdater;
        private readonly IFileInformationService _fileInformationService;

        public EpisodeMetadataService(IEpisodeMetadataRepository metadataRepository,
            ITvShowMetadataUpdater metadataUpdater,
            IFileInformationService fileInformationService)
        {
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
            EpisodeNumber episode = TvShowHelper.FindEpisodeNumberFromFile(episodeFile);
            EpisodeMetadata metadata = _metadataUpdater.GetEpisodeMetadata(serieId, episode.SeasonNumber, episode.EpisodeSeasonNumber);
            if (metadata == null)
            {
                throw new ItemNotFoundException(episodeFile);
            }
            metadata.FileInformation = _fileInformationService.GetVideoFileInformation(episodeFile);
            Save(episodeFile, metadata);
        }

        public void Delete(string episodeFile)
        {
            _metadataRepository.Delete(episodeFile);
        }
    }
}
