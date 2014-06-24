using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.TvShows.Metadata
{
    public class TvShowMetadataService : ITvShowMetadataService
    {
        private readonly ITvShowImagesService _imagesService;
        private readonly ITvShowMetadataRepository _metadataRepository;
        private readonly ITvShowMetadataUpdater _metadataUpdater;

        public TvShowMetadataService(ITvShowImagesService imagesService, ITvShowMetadataRepository metadataRepository, ITvShowMetadataUpdater metadataUpdater)
        {
            _imagesService = imagesService;
            _metadataRepository = metadataRepository;
            _metadataUpdater = metadataUpdater;
        }

        public TvShowMetadata Get(string path)
        {
            return _metadataRepository.Get(path);
        }

        public void Save(string path, TvShowMetadata metadata)
        {
            _metadataRepository.Save(path, metadata);
        }

        public void Update(string path)
        {
            string seriesId = GetSeriesId(path);
            FullSerie serie = _metadataUpdater.GetTvShowMetadata(seriesId);
            FixSerieUrl(serie);
            UpdateInformationMetadata(path, serie);
            UpdateImages(path, serie.Id);
        }

        public void Delete(string path)
        {
            _metadataRepository.Delete(path);
            _imagesService.Delete(path);
        }

        public IEnumerable<Series> FindSeries(string name)
        {
            return _metadataUpdater.FindSeries(name);
        }

        public AvailableTvShowImages FindImages(string seriesId)
        {
            return _metadataUpdater.FindImages(seriesId);
        }

        private FullSerie FindFullSerie(string path)
        {
            string seriesId = GetSeriesId(path);
            return _metadataUpdater.GetTvShowMetadata(seriesId);
        }

        private string GetSeriesId(string path)
        {
            TvShowMetadata metadata = Get(path);
            if (string.IsNullOrEmpty(metadata.Id))
            {
                return FindIdFromPath(path);
            }
            return metadata.Id;
        }

        private string FindIdFromPath(string path)
        {
            string folderName = Path.GetFileName(path);
            IEnumerable<Series> series = FindSeries(folderName);
            if (!series.Any())
            {
                string message = string.Format("Couldn't find any series corresponding to \"{0}\"", folderName);
                throw new ItemNotFoundException(message);
            }
            return series.First().SeriesId;
        }

        private void FixSerieUrl(FullSerie serie)
        {
            serie.Fanart = TvShowHelper.ExpandImagesUrl(serie.Fanart);
            serie.Banner = TvShowHelper.ExpandImagesUrl(serie.Banner);
            serie.Poster = TvShowHelper.ExpandImagesUrl(serie.Poster);
        }

        private void UpdateInformationMetadata(string path, FullSerie serie)
        {
            TvShowMetadata metadata = MapFullSerieToMetadata(serie);
            UpdateActorsMetadata(path, metadata);
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
            metadata.PremieredDate = serie.FirstAired;
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

        private void UpdateActorsMetadata(string path, TvShowMetadata metadata)
        {
            IEnumerable<Actor> actors = _metadataUpdater.FindActors(metadata.Id);
            foreach (Actor thetvdbActor in actors)
            {
                ActorMetadata actor = new ActorMetadata
                {
                    Name = thetvdbActor.Name,
                    Role = thetvdbActor.Role,
                    Thumb = TvShowHelper.ExpandImagesUrl(thetvdbActor.Image)
                };
                metadata.Actors.Add(actor);
            }
        }

        private void UpdateImages(string path, string serieId)
        {
            AvailableTvShowImages images = _metadataUpdater.FindImages(serieId);
            _imagesService.Update(path, images);
        }
    }
}
