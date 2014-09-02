using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
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
    public class ArtistViewModel : MediaViewModel<IAlbumViewModel>, IArtistViewModel
    {
        private readonly IArtistMetadataService _metadataService;
        private readonly IBusyProvider _busyProvider;

        public string Path { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public override string DisplayName
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
            IDialogViewer dialogViewer,
            string path)
            // TODO: add dummy album
            : base(busyProvider, dialogViewer, null)
        {
            _metadataService = metadataService;
            _busyProvider = busyProvider;
            Name = viewModelFactory.GetStringCachedProperty(path, true);
            Path = path;

            Genres = new DashDelimitedCollectionViewModel<string>(s => s);
            Moods = new DashDelimitedCollectionViewModel<string>(s => s);
            Styles = new DashDelimitedCollectionViewModel<string>(s => s);
            YearsActive = new DashDelimitedCollectionViewModel<int>(int.Parse);

            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this, progressManager, busyProvider);
            SaveCommand = new SaveMetadataCommand(this);
            DeleteCommand = new DeleteMetadataCommand(this);
        }

        protected override async Task RefreshInternal()
        {
            ArtistMetadata metadata = await _metadataService.Get(Path);
            RefreshFromMetadata(metadata);
        }

        protected override async Task<IEnumerable<ProgressItem>> UpdateInternal()
        {
            await Refresh();
            if (string.IsNullOrEmpty(Name.Value))
            {
                Lazy<string> displayName = new Lazy<string>(() => DisplayName);
                return new List<ProgressItem> { new ProgressItem(Path, displayName, UpdateMethod) };
            }
            return Enumerable.Empty<ProgressItem>();
        }

        protected override async Task SaveInternal()
        {
            Name.Save();
            ArtistMetadata metadata = CreateMetadata();
            await _metadataService.Save(Path, metadata);
        }

        protected override async Task DeleteInternal()
        {
            await _metadataService.Delete(Path);
            await Refresh();
        }

        protected override Task LoadChildrenInternal()
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

        private async Task UpdateMethod()
        {
            using (_busyProvider.DoWork())
            {
                await _metadataService.Update(Path);
                await Refresh();
            }
        }
    }
}