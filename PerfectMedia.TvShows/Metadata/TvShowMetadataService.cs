using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows.Metadata
{
    public class TvShowMetadataService : ITvShowMetadataService
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly ITvShowImagesService _imagesService;
        private readonly ITvShowMetadataRepository _metadataRepository;
        private readonly ITvShowMetadataUpdater _metadataUpdater;

        public TvShowMetadataService(IFileSystemService fileSystemService, ITvShowImagesService imagesService, ITvShowMetadataRepository metadataRepository, ITvShowMetadataUpdater metadataUpdater)
        {
            _fileSystemService = fileSystemService;
            _imagesService = imagesService;
            _metadataRepository = metadataRepository;
            _metadataUpdater = metadataUpdater;
        }

        public async Task<TvShowMetadata> Get(string path)
        {
            TvShowMetadata metadata = await _metadataRepository.Get(path);
            foreach (ActorMetadata actor in metadata.Actors)
            {
                actor.ThumbPath = ActorMetadata.GetActorThumbPath(path, actor.Name);
            }
            return metadata;
        }

        public void Save(string path, TvShowMetadata metadata)
        {
            _metadataRepository.Save(path, metadata);
        }

        public async Task Update(string path)
        {
            FullSerie serie = await FindFullSerie(path);
            await UpdateInformationMetadata(path, serie);
            await UpdateImages(path, serie.Id);
        }

        public async Task Delete(string path)
        {
            await _metadataRepository.Delete(path);
            await _imagesService.Delete(path);
        }

        public Task<IEnumerable<Series>> FindSeries(string name)
        {
            return _metadataUpdater.FindSeries(name);
        }

        public Task<AvailableTvShowImages> FindImages(string seriesId)
        {
            return _metadataUpdater.FindImages(seriesId);
        }

        public async Task<AvailableTvShowImages> FindImagesFromPath(string path)
        {
            string seriesId = await FindIdFromPath(path);
            return await FindImages(seriesId);
        }

        public async Task<AvailableSeasonImages> FindSeasonImages(string seasonPath)
        {
            string seriePath = _fileSystemService.GetParentFolder(seasonPath, 1);
            string serieId = await GetSeriesId(seriePath);
            AvailableTvShowImages images = await FindImages(serieId);
            int seasonNumber = TvShowHelper.FindSeasonNumberFromFolder(seasonPath);
            return images.Seasons[seasonNumber];
        }

        public Task DeleteImages(string path)
        {
            return _imagesService.Delete(path);
        }

        private async Task<FullSerie> FindFullSerie(string path)
        {
            string seriesId = await GetSeriesId(path);
            FullSerie fullSerie = await _metadataUpdater.GetTvShowMetadata(seriesId);
            if (fullSerie == null)
            {
                throw new TvShowNotFoundException(path);
            }
            return fullSerie;
        }

        private async Task<string> GetSeriesId(string path)
        {
            TvShowMetadata metadata = await Get(path);
            if (string.IsNullOrEmpty(metadata.Id))
            {
                return await FindIdFromPath(path);
            }
            return metadata.Id;
        }

        private async Task<string> FindIdFromPath(string path)
        {
            string folderName = Path.GetFileName(path);
            IEnumerable<Series> series = await FindSeries(folderName);
            if (!series.Any())
            {
                string message = string.Format("Couldn't find any series corresponding to \"{0}\"", folderName);
                throw new TvShowNotFoundException(message);
            }
            return series.First().SeriesId;
        }

        private async Task UpdateInformationMetadata(string path, FullSerie serie)
        {
            TvShowMetadata metadata = MapFullSerieToMetadata(serie);
            await UpdateActorsMetadata(path, metadata);
            Save(path, metadata);
        }

        private TvShowMetadata MapFullSerieToMetadata(FullSerie serie)
        {
            TvShowMetadata metadata = new TvShowMetadata();
            metadata.Genres = MapGenres(serie);
            metadata.Id = serie.Id;
            metadata.ImdbId = serie.ImdbId;
            metadata.Language = serie.Language;
            metadata.MpaaRating = serie.ContentRating;
            metadata.Plot = serie.Overview;
            metadata.Premiered = serie.FirstAired;
            metadata.Rating = serie.Rating;
            metadata.RuntimeInMinutes = serie.Runtime;
            //metadata.State = serie.Status;
            metadata.Studio = serie.Network;
            metadata.Title = serie.SeriesName;

            return metadata;
        }

        private static List<string> MapGenres(FullSerie serie)
        {
            return serie.Genre.Split('|')
                .Where(genre => !string.IsNullOrEmpty(genre))
                .ToList();
        }

        private async Task UpdateActorsMetadata(string path, TvShowMetadata metadata)
        {
            IEnumerable<Actor> actors = await _metadataUpdater.FindActors(metadata.Id);
            foreach (Actor thetvdbActor in actors)
            {
                ActorMetadata actor = new ActorMetadata
                {
                    Name = thetvdbActor.Name,
                    Role = thetvdbActor.Role,
                    Thumb = TvShowHelper.ExpandImagesUrl(thetvdbActor.Image),
                    ThumbPath = ActorMetadata.GetActorThumbPath(path, thetvdbActor.Name)
                };
                metadata.Actors.Add(actor);
            }
        }

        private async Task UpdateImages(string path, string serieId)
        {
            AvailableTvShowImages images = await _metadataUpdater.FindImages(serieId);
            await _imagesService.Update(path, images);
        }
    }
}
