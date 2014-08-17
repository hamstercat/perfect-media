using System.Windows.Input;
using PerfectMedia.UI.Busy;
using PropertyChanged;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Images.Selection
{
    [ImplementPropertyChanged]
    public class ChooseImageFileViewModel : BaseViewModel, IChooseImageFileViewModel
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IImageSelectionViewModel _imageSelectionViewModel;
        private readonly IBusyProvider _busyProvider;
        private readonly string _path;

        public string Url { get; set; }
        public bool IsClosed { get; set; }
        public ICommand DownloadCommand { get; private set; }
        public ICommand LoadFileCommand { get; private set; }

        public ChooseImageFileViewModel(IFileSystemService fileSystemService,
            IImageSelectionViewModel imageSelectionViewModel,
            IBusyProvider busyProvider,
            string path)
        {
            _fileSystemService = fileSystemService;
            _imageSelectionViewModel = imageSelectionViewModel;
            _busyProvider = busyProvider;
            _path = path;

            DownloadCommand = new DownloadCommand(this);
            LoadFileCommand = new LoadFileCommand(this);
        }

        public async Task SaveLocalFile()
        {
            using (_busyProvider.DoWork())
            {
                await _fileSystemService.CopyFile(Url, _path);
                IsClosed = true;
                _imageSelectionViewModel.IsClosed = true;
            }
        }

        public async Task DownloadFile()
        {
            using (_busyProvider.DoWork())
            {
                await _fileSystemService.DownloadImage(_path, Url);
                IsClosed = true;
                _imageSelectionViewModel.IsClosed = true;
            }
        }
    }
}
