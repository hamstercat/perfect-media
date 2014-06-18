using PerfectMedia.Metadata.TheTvDbDataContracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ThetvdbActor = PerfectMedia.Metadata.TheTvDbDataContracts.Actor;

namespace PerfectMedia.Metadata
{
    public class TvShowMetadataService : ITvShowMetadataService
    {
        private readonly ITvShowLocalMetadataService _localMetadataService;
        private readonly IRestApiWrapper _restApiWrapper;
        private readonly IFileSystemService _filesystemService;

        private string TheTvDbUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["TheTvDbUrl"];
            }
        }
        
        private string TheTvDbApiKey
        {
            get
            {
                return ConfigurationManager.AppSettings["TheTvDbApiKey"];
            }
        }

        public TvShowMetadataService(ITvShowLocalMetadataService localMetadataService, IRestApiWrapper restApiWrapper, IFileSystemService filesystemService)
        {
            _localMetadataService = localMetadataService;
            _restApiWrapper = restApiWrapper;
            _filesystemService = filesystemService;
        }

        public IEnumerable<Series> FindSeries(string name)
        {
            string url = string.Format("api/GetSeries.php?seriesname={0}&language=en", HttpUtility.UrlEncode(name));
            return _restApiWrapper.Get<List<Series>>(url);
        }

        public void UpdateMetadata(string path)
        {
            FullSerie serie = FindFullSerie(path);
            FixSerieUrl(serie);
            UpdateInformationMetadata(path, serie);
            UpdateImages(path, serie);
        }

        private FullSerie FindFullSerie(string path)
        {
            string seriesId = GetSeriesId(path);
            string url = string.Format("api/{0}/series/{1}/en.xml", TheTvDbApiKey, seriesId);
            return _restApiWrapper.Get<FullSerie>(url);
        }

        private string GetSeriesId(string path)
        {
            TvShowMetadata metadata = _localMetadataService.GetLocalMetadata(path);
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
            serie.Fanart = ExpandImagesUrl(serie.Fanart);
            serie.Banner = ExpandImagesUrl(serie.Banner);
            serie.Poster = ExpandImagesUrl(serie.Poster);
        }

        private string ExpandImagesUrl(string relativePath)
        {
            string imageRelativePath = "banners";
            if (!relativePath.StartsWith("/"))
            {
                imageRelativePath += "/";
            }
            imageRelativePath += relativePath;
            return new Uri(new Uri(TheTvDbUrl), imageRelativePath).ToString();
        }

        private void UpdateInformationMetadata(string path, FullSerie serie)
        {
            TvShowMetadata metadata = MapFullSerieToMetadata(serie);
            UpdateActorsMetadata(path, metadata);
            _localMetadataService.SaveLocalMetadata(path, metadata);
        }

        private void UpdateActorsMetadata(string path, TvShowMetadata metadata)
        {
            string url = string.Format("api/{0}/series/{1}/actors.xml", TheTvDbApiKey, metadata.Id);
            List<ThetvdbActor> actors = _restApiWrapper.Get<List<ThetvdbActor>>(url);
            foreach (ThetvdbActor thetvdbActor in actors)
            {
                Actor actor = new Actor
                {
                    Name = thetvdbActor.Name,
                    Role = thetvdbActor.Role,
                    Thumb = ExpandImagesUrl(thetvdbActor.Image)
                };
                metadata.Actors.Add(actor);
                SaveActorMetadata(path, actor);
            }
        }

        private void SaveActorMetadata(string path, Actor actor)
        {
            string folderName = Path.Combine(path, ".actors");
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            string fileName = actor.Name.Replace(" ", "_") + ".jpg";
            string fullFileName = Path.Combine(folderName, fileName);
            _filesystemService.DownloadFile(fullFileName, actor.Thumb);
        }

        private void UpdateImages(string path, FullSerie serie)
        {
            TvShowImages images = _localMetadataService.GetLocalImages(path);
            if (!File.Exists(images.FanartUrl))
            {
                _localMetadataService.SaveFanart(path, serie.Fanart);
            }
            if (!File.Exists(images.PosterUrl))
            {
                _localMetadataService.SavePoster(path, serie.Poster);
            }
            if (!File.Exists(images.BannerUrl))
            {
                _localMetadataService.SaveBanner(path, serie.Banner);
            }
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
    }
}
