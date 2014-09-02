using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Images;

namespace PerfectMedia.UI.Actors
{
    public class ActorViewModelFactory : IActorViewModelFactory
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IBusyProvider _busyProvider;

        public ActorViewModelFactory(IFileSystemService fileSystemService, IBusyProvider busyProvider)
        {
            _fileSystemService = fileSystemService;
            _busyProvider = busyProvider;
        }

        public IImageViewModel GetImage(bool horizontalAlignement)
        {
            return new ImageViewModel(_fileSystemService, _busyProvider, horizontalAlignement);
        }
    }
}