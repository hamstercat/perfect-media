using System.Collections.Generic;
using System.Threading.Tasks;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Progress;

namespace PerfectMedia.UI.Music.Tracks
{
    public class TrackViewModel : MediaViewModel<object>, ITrackViewModel
    {
        public string Path { get; private set; }

        public override string DisplayName
        {
            get { return System.IO.Path.GetFileName(Path); }
        }

        public TrackViewModel(IBusyProvider busyProvider, IDialogViewer dialogViewer, string path)
            : base(busyProvider, dialogViewer)
        {
            Path = path;
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