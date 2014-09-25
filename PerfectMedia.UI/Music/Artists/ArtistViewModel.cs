﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PerfectMedia.Music;
using PerfectMedia.Music.Albums;
using PerfectMedia.Music.Artists;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Cache;
using PerfectMedia.UI.Images;
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
        private readonly IMusicViewModelFactory _viewModelFactory;
        private readonly IMusicFileService _musicFileService;
        private readonly IBusyProvider _busyProvider;

        public string Path { get; private set; }
        public IImageViewModel Fanart { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public override string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(Name.OriginalValue))
                {
                    return System.IO.Path.GetFileNameWithoutExtension(Path);
                }
                return Name.OriginalValue;
            }
        }

        [RequiredCached]
        public IPropertyViewModel<string> Name { get; private set; }

        [LocalizedRequired]
        public string Id { get; set; }

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
            IMusicFileService musicFileService,
            IMusicImageUpdater imageUpdater,
            IProgressManagerViewModel progressManager,
            IBusyProvider busyProvider,
            IDialogViewer dialogViewer,
            IKeyDataStore keyDataStore,
            string path)
            : base(busyProvider, dialogViewer, viewModelFactory.GetAlbum("dummy", null))
        {
            _metadataService = metadataService;
            _viewModelFactory = viewModelFactory;
            _musicFileService = musicFileService;
            _busyProvider = busyProvider;
            Name = new RequiredPropertyDecorator<string>(new StringCachedPropertyDecorator(keyDataStore, path));
            Path = path;
            Fanart = viewModelFactory.GetImage(true, new ArtistFanartImageStrategy(imageUpdater, this));

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
            RefreshImage();
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

        protected override async Task LoadChildrenInternal()
        {
            IEnumerable<AlbumFile> albums = await _musicFileService.GetAlbums(Path);
            foreach (AlbumFile album in albums)
            {
                IAlbumViewModel albumViewModel = _viewModelFactory.GetAlbum(album.Path, this);
                Children.Add(albumViewModel);
            }
        }

        private void RefreshFromMetadata(ArtistMetadata metadata)
        {
            Biography = metadata.Biography;
            BornOn = metadata.BornOn;
            DiedOn = metadata.DiedOn;
            DisbandedOn = metadata.DisbandedOn;
            FormedOn = metadata.FormedOn;
            Genres.ReplaceWith(metadata.Genres);
            Id = metadata.Mbid;
            Instruments = metadata.Instruments;
            Moods.ReplaceWith(metadata.Moods);
            Name.Value = metadata.Name;
            Name.Save();
            Styles.ReplaceWith(metadata.Styles);
            YearsActive.ReplaceWith(metadata.YearsActive);
        }

        private void RefreshImage()
        {
            string fanartPath = _musicFileService.GetArtistImage(Path);
            Fanart.RefreshImage(fanartPath);
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
                Mbid = Id,
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