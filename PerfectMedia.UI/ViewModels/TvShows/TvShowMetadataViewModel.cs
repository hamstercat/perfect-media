using PerfectMedia.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PerfectMedia.UI.ViewModels.TvShows
{
    public class TvShowMetadataViewModel : BaseViewModel, IMetadataProvider
    {
        private readonly ITvShowMetadataService _tvShowMetadataService;
        private bool _lazyLoaded;

        public string Path { get; private set; }
        public ObservableCollection<ActorViewModel> Actors { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        #region Metadata
        private int _state;
        public int State
        {
            get
            {
                InitialLoadInformation();
                return _state;
            }
            set
            {
                _state = value;
                OnPropertyChanged("State");
            }
        }

        private string _title;
        public string Title
        {
            get
            {
                InitialLoadInformation();
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private string _id;
        public string Id
        {
            get
            {
                InitialLoadInformation();
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _mpaaRating;
        public string MpaaRating
        {
            get
            {
                InitialLoadInformation();
                return _mpaaRating;
            }
            set
            {
                _mpaaRating = value;
                OnPropertyChanged("MpaaRating");
            }
        }

        private ObservableCollection<string> _genres;
        public ObservableCollection<string> Genres
        {
            get
            {
                InitialLoadInformation();
                return _genres;
            }
            set
            {
                _genres = value;
                OnPropertyChanged("Genres");
            }
        }

        private string _imdbId;
        public string ImdbId
        {
            get
            {
                InitialLoadInformation();
                return _imdbId;
            }
            set
            {
                _imdbId = value;
                OnPropertyChanged("ImdbId");
            }
        }

        private string _plot;
        public string Plot
        {
            get
            {
                InitialLoadInformation();
                return _plot;
            }
            set
            {
                _plot = value;
                OnPropertyChanged("Plot");
            }
        }

        private int _runtimeInMinutes;
        public int RuntimeInMinutes
        {
            get
            {
                InitialLoadInformation();
                return _runtimeInMinutes;
            }
            set
            {
                _runtimeInMinutes = value;
                OnPropertyChanged("RuntimeInMinutes");
            }
        }

        private double _rating;
        public double Rating
        {
            get
            {
                InitialLoadInformation();
                return _rating;
            }
            set
            {
                _rating = value;
                OnPropertyChanged("Rating");
            }
        }

        private DateTime _premieredDate;
        public DateTime PremieredDate
        {
            get
            {
                InitialLoadInformation();
                return _premieredDate;
            }
            set
            {
                _premieredDate = value;
                OnPropertyChanged("PremieredDate");
            }
        }

        private string _studio;
        public string Studio
        {
            get
            {
                InitialLoadInformation();
                return _studio;
            }
            set
            {
                _studio = value;
                OnPropertyChanged("Studio");
            }
        }

        private string _language;
        public string Language
        {
            get
            {
                InitialLoadInformation();
                return _language;
            }
            set
            {
                _language = value;
                OnPropertyChanged("Language");
            }
        }

        // Find out if we really need the two following properties in the .nfo
        private string EpisodeUrl { get; set; }
        private string EpisodeUrlCache { get; set; }
        #endregion

        public TvShowMetadataViewModel(ITvShowMetadataService tvShowMetadataService, string path)
        {
            _tvShowMetadataService = tvShowMetadataService;
            Path = path;
            _lazyLoaded = false;
            Genres = new ObservableCollection<string>();
            Actors = new ObservableCollection<ActorViewModel>();
        }

        public void Refresh()
        {
            TvShowMetadata metadata = _tvShowMetadataService.GetLocalMetadata(Path);
            RefreshFromMetadata(metadata);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        private void InitialLoadInformation()
        {
            if (!_lazyLoaded)
            {
                _lazyLoaded = true;
                Refresh();
            }
        }

        private void RefreshFromMetadata(TvShowMetadata metadata)
        {
            State = metadata.State;
            Title = metadata.Title;
            Id = metadata.Id;
            MpaaRating = metadata.MpaaRating;
            ImdbId = metadata.ImdbId;
            Plot = metadata.Plot;
            RuntimeInMinutes = metadata.RuntimeInMinutes;
            Rating = metadata.Rating;
            PremieredDate = metadata.PremieredDate;
            Studio = metadata.Studio;
            Language = metadata.Language;

            EpisodeUrl = metadata.EpisodeGuide.UrlInformation.Url;
            EpisodeUrlCache = metadata.EpisodeGuide.UrlInformation.Cache;
            
            Genres.Clear();
            foreach (string genre in metadata.Genres)
            {
                Genres.Add(genre);
            }

            AddActors(metadata.Actors);
        }

        private void AddActors(List<Actor> actors)
        {
            Actors.Clear();
            foreach (Actor actor in actors)
            {
                ActorViewModel actorViewModel = new ActorViewModel
                {
                    Name = actor.Name,
                    Role = actor.Role,
                    Thumb = actor.Thumb
                };
                Actors.Add(actorViewModel);
            }
        }
    }
}
