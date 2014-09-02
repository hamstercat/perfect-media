using System.Collections.Generic;
using System.Threading.Tasks;
using PerfectMedia.Music;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Music.Tracks;
using PerfectMedia.UI.Progress;

namespace PerfectMedia.UI.Music.Albums
{
    public class AlbumViewModel : MediaViewModel<ITrackViewModel>, IAlbumViewModel
    {
        private readonly IMusicFileService _musicFileService;
        private readonly IMusicViewModelFactory _viewModelFactory;

        public string Path { get; private set; }

        public override string DisplayName
        {
            get { return System.IO.Path.GetFileName(Path); }
        }

        public AlbumViewModel(IMusicFileService musicFileService,
            IMusicViewModelFactory viewModelFactory,
            IBusyProvider busyProvider,
            IDialogViewer dialogViewer,
            string path)
            : base(busyProvider, dialogViewer, viewModelFactory.GetTrack("dummy"))
        {
            _musicFileService = musicFileService;
            _viewModelFactory = viewModelFactory;
            Path = path;
        }

        protected override async Task LoadChildrenInternal()
        {
            IEnumerable<TrackFile> tracks = await _musicFileService.GetTracks(Path);
            foreach (TrackFile track in tracks)
            {
                ITrackViewModel trackViewModel = _viewModelFactory.GetTrack(track.Path);
                Children.Add(trackViewModel);
            }
        }

        protected override Task RefreshInternal()
        {
            throw new System.NotImplementedException();
        }

        protected override Task<IEnumerable<ProgressItem>> UpdateInternal()
        {
            throw new System.NotImplementedException();
        }

        protected override Task SaveInternal()
        {
            throw new System.NotImplementedException();
        }

        protected override Task DeleteInternal()
        {
            throw new System.NotImplementedException();
        }
    }
}