using System.Threading.Tasks;
using PerfectMedia.UI.Busy;
using PerfectMedia.UI.Selection;
using PropertyChanged;

namespace PerfectMedia.UI.Images.Selection
{
    [ImplementPropertyChanged]
    public class ImageSelectionViewModel : SelectionViewModel<Image>, IImageSelectionViewModel
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly string _path;

        public bool HorizontalAlignement { get; private set; }
        public IChooseImageFileViewModel Download { get; private set; }

        public ImageSelectionViewModel(IFileSystemService fileSystemService,
            IBusyProvider busyProvider,
            string path,
            bool horizontalAlignement)
            : base(busyProvider, new Image { Url = path })
        {
            _fileSystemService = fileSystemService;
            _path = path;
            HorizontalAlignement = horizontalAlignement;
            Download = new ChooseImageFileViewModel(fileSystemService, this, busyProvider, path);
        }

        protected override async Task SaveInternal(Image selectedItem)
        {
            await _fileSystemService.DownloadImage(_path, selectedItem.Url);
        }
    }
}
