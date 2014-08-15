using System.Windows.Input;
using PropertyChanged;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Images.Selection
{
    [ImplementPropertyChanged]
    public class ChooseImageFileViewModel : BaseViewModel, IChooseImageFileViewModel
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IImageSelectionViewModel _imageSelectionViewModel;
        private readonly string _path;

        public string Url { get; set; }
        public bool IsClosed { get; set; }
        public ICommand DownloadCommand { get; private set; }
        public ICommand LoadFileCommand { get; private set; }

        public ChooseImageFileViewModel(IFileSystemService fileSystemService, IImageSelectionViewModel imageSelectionViewModel, string path)
        {
            _fileSystemService = fileSystemService;
            _imageSelectionViewModel = imageSelectionViewModel;
            _path = path;

            DownloadCommand = new DownloadCommand(this);
            LoadFileCommand = new LoadFileCommand(this);
        }

        public async Task SaveLocalFile()
        {
            await _fileSystemService.CopyFile(Url, _path);
            IsClosed = true;
            _imageSelectionViewModel.IsClosed = true;
        }

        public async Task DownloadFile()
        {
            await _fileSystemService.DownloadImage(_path, Url);
            IsClosed = true;
            _imageSelectionViewModel.IsClosed = true;
        }
    }
}
