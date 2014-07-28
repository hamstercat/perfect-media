using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfectMedia.UI.Images.Selection
{
    [ImplementPropertyChanged]
    public class ChooseImageFileViewModel : BaseViewModel, IChooseImageFileViewModel
    {
        private IFileSystemService _fileSystemService;
        private IImageSelectionViewModel _imageSelectionViewModel;
        private string _path;

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

        public void SaveLocalFile()
        {
            _fileSystemService.CopyFile(Url, _path);
            IsClosed = true;
            _imageSelectionViewModel.IsClosed = true;
        }

        public void DownloadFile()
        {
            _fileSystemService.DownloadImage(_path, Url);
            IsClosed = true;
            _imageSelectionViewModel.IsClosed = true;
        }
    }
}
