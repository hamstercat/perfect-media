using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfectMedia.UI.Images
{
    [ImplementPropertyChanged]
    public class ChooseImageFileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Url { get; set; }
        public bool IsClosed { get; set; }
        public ICommand DownloadCommand { get; private set; }
        public ICommand LoadFileCommand { get; private set; }

        public ChooseImageFileViewModel(IFileSystemService fileSystemService, IImageViewModel imageViewModel)
        {
            DownloadCommand = new DownloadCommand(fileSystemService, imageViewModel, this);
            LoadFileCommand = new LoadFileCommand(fileSystemService, imageViewModel, this);
        }
    }
}
