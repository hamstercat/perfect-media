using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Images;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.TvShows.Shows;
using PerfectMedia.UI.Validations;
using PropertyChanged;

namespace PerfectMedia.UI.TvShows.Episodes
{
    [ImplementPropertyChanged]
    public class EpisodeViewModel : MediaViewModel<object>, IEpisodeViewModel
    {
        private readonly IEpisodeMetadataService _metadataService;
        private readonly ITvShowViewModel _tvShowMetadata;
        private readonly IBusyProvider _busyProvider;
        private bool _localMetadataExists;

        [Rating]
        public double? Rating { get; set; }

        [RequiredCached]
        public ICachedPropertyViewModel<string> Title { get; private set; }

        [RequiredCached]
        public ICachedPropertyViewModel<int?> SeasonNumber { get; private set; }

        [RequiredCached]
        public ICachedPropertyViewModel<int?> EpisodeNumber { get; private set; }

        [Positive]
        public int? PlayCount { get; set; }

        [Positive]
        public int? DisplaySeason { get; set; }

        [Positive]
        public int? DisplayEpisode { get; set; }

        public string Plot { get; set; }
        public IImageViewModel ImagePath { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? LastPlayed { get; set; }
        public DashDelimitedCollectionViewModel<string> Credits { get; set; }
        public DashDelimitedCollectionViewModel<string> Directors { get; set; }
        public DateTime? AiredDate { get; set; }
        public double? EpisodeBookmarks { get; set; }

        public override string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(Title.CachedValue))
                {
                    return System.IO.Path.GetFileName(Path);
                }
                if (SeasonNumber == null || EpisodeNumber == null)
                {
                    return Title.CachedValue;
                }
                return string.Format("{0}x{1:d2}{2}{3}",
                    SeasonNumber.CachedValue,
                    EpisodeNumber.CachedValue,
                    General.Semicolon,
                    Title.CachedValue);
            }
        }

        public string Path { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public EpisodeViewModel(ITvShowViewModelFactory viewModelFactory,
            IEpisodeMetadataService metadataService,
            ITvShowViewModel tvShowMetadata,
            IProgressManagerViewModel progressManager,
            IBusyProvider busyProvider,
            IDialogViewer dialogViewer,
            string path)
            : base(busyProvider, dialogViewer)
        {
            _metadataService = metadataService;
            _tvShowMetadata = tvShowMetadata;
            _busyProvider = busyProvider;

            Title = viewModelFactory.GetStringCachedProperty(path + "?title", true);
            Title.PropertyChanged += CachedPropertyChanged;
            SeasonNumber = viewModelFactory.GetIntCachedProperty(path + "?seasonNumber", true);
            SeasonNumber.PropertyChanged += CachedPropertyChanged;
            EpisodeNumber = viewModelFactory.GetIntCachedProperty(path + "?episodeNumber", true);
            EpisodeNumber.PropertyChanged += CachedPropertyChanged;
            Path = path;

            Credits = new DashDelimitedCollectionViewModel<string>(s => s);
            Directors = new DashDelimitedCollectionViewModel<string>(s => s);
            ImagePath = viewModelFactory.GetImage(true);

            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this, progressManager, busyProvider);
            SaveCommand = new SaveMetadataCommand(this);
            DeleteCommand = new DeleteMetadataCommand(this);
        }

        private void CachedPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("Title");
            OnPropertyChanged("SeasonNumber");
            OnPropertyChanged("EpisodeNumber");
            OnPropertyChanged("DisplayName");
        }

        protected override async Task RefreshInternal()
        {
            EpisodeMetadata metadata = await _metadataService.Get(Path);
            RefreshFromMetadata(metadata);
        }

        protected override async Task<IEnumerable<ProgressItem>> UpdateInternal()
        {
            List<ProgressItem> items = new List<ProgressItem>();
            foreach (ProgressItem item in await _tvShowMetadata.Update())
            {
                items.Add(item);
            }

            await Refresh();
            if (!_localMetadataExists)
            {
                Lazy<string> displayName = new Lazy<string>(() => DisplayName);
                items.Add(new ProgressItem(Path, displayName, UpdateMethod));
            }
            return items;
        }

        protected override async Task SaveInternal()
        {
            Title.Save();
            SeasonNumber.Save();
            EpisodeNumber.Save();
            EpisodeMetadata metadata = CreateMetadata();
            await _metadataService.Save(Path, metadata);
        }

        protected override async Task DeleteInternal()
        {
            await _metadataService.Delete(Path);
            await Refresh();
        }

        protected override Task LoadChildrenInternal()
        {
            // Nothing to do
            return Task.Delay(0);
        }

        private void RefreshFromMetadata(EpisodeMetadata metadata)
        {
            Title.Value = metadata.Title;
            Title.Save();
            Rating = metadata.Rating;
            SeasonNumber.Value = metadata.SeasonNumber;
            SeasonNumber.Save();
            EpisodeNumber.Value = metadata.EpisodeNumber;
            EpisodeNumber.Save();
            Plot = metadata.Plot;
            ImagePath.RefreshImage(metadata.ImagePath);
            ImageUrl = metadata.ImageUrl;
            PlayCount = metadata.PlayCount;
            LastPlayed = metadata.LastPlayed;
            AiredDate = metadata.AiredDate;
            DisplaySeason = metadata.DisplaySeason;
            DisplayEpisode = metadata.DisplayEpisode;
            EpisodeBookmarks = metadata.EpisodeBookmarks;

            Credits.ReplaceWith(metadata.Credits);
            Directors.ReplaceWith(metadata.Director);

            _localMetadataExists = metadata.FileInformation != null;
        }

        private EpisodeMetadata CreateMetadata()
        {
            return new EpisodeMetadata
            {
                Title = Title.Value,
                Rating = Rating,
                SeasonNumber = SeasonNumber.Value.Value,
                EpisodeNumber = EpisodeNumber.Value.Value,
                Plot = Plot,
                ImagePath = ImagePath.Path,
                ImageUrl = ImageUrl,
                PlayCount = PlayCount,
                LastPlayed = LastPlayed,
                Credits = Credits.Collection.ToList(),
                Director = Directors.Collection.ToList(),
                AiredDate = AiredDate,
                DisplaySeason = DisplaySeason,
                DisplayEpisode = DisplayEpisode,
                EpisodeBookmarks = EpisodeBookmarks
            };
        }

        private async Task UpdateMethod()
        {
            using (_busyProvider.DoWork())
            {
                await _metadataService.Update(Path, _tvShowMetadata.Id);
                await Refresh();
            }
        }
    }
}
