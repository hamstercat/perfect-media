using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.Music;
using PerfectMedia.Music.Artists;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Music.Albums;
using PerfectMedia.UI.Progress;
using PerfectMedia.UI.Validations;
using PropertyChanged;

namespace PerfectMedia.UI.Music.Artists
{
    [ImplementPropertyChanged]
    public class ArtistViewModel : BaseViewModel, IArtistViewModel, ITreeViewItemViewModel
    {
        private readonly IArtistMetadataService _metadataService;
        private readonly IBusyProvider _busyProvider;
        private bool _lazyLoaded;

        public string Path { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ObservableCollection<IAlbumViewModel> Albums { get; private set; }

        public string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(Name.CachedValue))
                {
                    return System.IO.Path.GetFileNameWithoutExtension(Path);
                }
                return Name.CachedValue;
            }
        }

        [RequiredCached]
        public ICachedPropertyViewModel<string> Name { get; private set; }

        public string Biography { get; set; }
        public DateTime? BornOn { get; set; }
        public DateTime? DiedOn { get; set; }
        public DateTime? DisbandedOn { get; set; }
        public DateTime? FormedOn { get; set; }
        public string Instruments { get; set; }
        public DashDelimitedCollectionViewModel<string> Genres { get; private set; }
        public DashDelimitedCollectionViewModel<string> Moods { get; private set; }
        public DashDelimitedCollectionViewModel<string> Styles { get; private set; }
        public DashDelimitedCollectionViewModel<int> YearsActive { get; private set; }

        public ArtistViewModel(IArtistMetadataService metadataService,
            IMusicViewModelFactory viewModelFactory,
            IProgressManagerViewModel progressManager,
            IBusyProvider busyProvider,
            string path)
        {
            _metadataService = metadataService;
            _busyProvider = busyProvider;
            Name = viewModelFactory.GetStringCachedProperty(path, true);
            Path = path;
            Albums = new ObservableCollection<IAlbumViewModel>();

            Genres = new DashDelimitedCollectionViewModel<string>(s => s);
            Moods = new DashDelimitedCollectionViewModel<string>(s => s);
            Styles = new DashDelimitedCollectionViewModel<string>(s => s);
            YearsActive = new DashDelimitedCollectionViewModel<int>(int.Parse);

            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this, progressManager, busyProvider);
            SaveCommand = new SaveMetadataCommand(this);
            DeleteCommand = new DeleteMetadataCommand(this);
        }

        public async Task Refresh()
        {
            using (_busyProvider.DoWork())
            {
                ArtistMetadata metadata = await _metadataService.Get(Path);
                RefreshFromMetadata(metadata);
            }
        }

        public async Task<IEnumerable<ProgressItem>> Update()
        {
            using (_busyProvider.DoWork())
            {
                ArtistMetadata metadata = await _metadataService.Get(Path);
                if (string.IsNullOrEmpty(metadata.Name))
                {
                    Lazy<string> displayName = new Lazy<string>(() => DisplayName);
                    return new List<ProgressItem> { new ProgressItem(Path, displayName, UpdateInternal) };
                }
                RefreshFromMetadata(metadata);
                return Enumerable.Empty<ProgressItem>();
            }
        }

        public async Task Save()
        {
            using (_busyProvider.DoWork())
            {
                Name.Save();
                ArtistMetadata metadata = CreateMetadata();
                await _metadataService.Save(Path, metadata);
            }
        }

        public async Task Delete()
        {
            using (_busyProvider.DoWork())
            {
                await _metadataService.Delete(Path);
                await Refresh();
            }
        }

        public async Task Load()
        {
            if (!_lazyLoaded)
            {
                _lazyLoaded = true;
                await Refresh();
            }
        }

        public Task LoadChildren()
        {
            // TODO: load albums
            return Task.Delay(0);
        }

        private void RefreshFromMetadata(ArtistMetadata metadata)
        {
            Biography = metadata.Biography;
            BornOn = metadata.BornOn;
            DiedOn = metadata.DiedOn;
            DisbandedOn = metadata.DisbandedOn;
            FormedOn = metadata.FormedOn;
            Genres.ReplaceWith(metadata.Genres);
            Instruments = metadata.Instruments;
            Moods.ReplaceWith(metadata.Moods);
            Name.Value = metadata.Name;
            Name.Save();
            Styles.ReplaceWith(metadata.Styles);
            YearsActive.ReplaceWith(metadata.YearsActive);
        }

        private ArtistMetadata CreateMetadata()
        {
            return new ArtistMetadata
            {
                // TODO: Albums
                Biography = Biography,
                BornOn = BornOn,
                DiedOn = DiedOn,
                DisbandedOn = DisbandedOn,
                FormedOn = FormedOn,
                Genres = Genres.Collection.ToList(),
                Instruments = Instruments,
                Moods = Moods.Collection.ToList(),
                Name = Name.Value,
                Styles = Styles.Collection.ToList(),
                YearsActive = YearsActive.Collection.ToList()
            };
        }

        private async Task UpdateInternal()
        {
            using (_busyProvider.DoWork())
            {
                await _metadataService.Update(Path);
                await Refresh();
            }
        }
    }
}