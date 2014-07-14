using PerfectMedia.UI.Metadata;
using PerfectMedia.UI.Progress;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfectMedia.UI.Movies
{
    [ImplementPropertyChanged]
    public class MovieViewModel : IMovieViewModel
    {
        public string Path { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public MovieViewModel(IProgressManagerViewModel progressManager, string path)
        {
            Path = path;
            RefreshCommand = new RefreshMetadataCommand(this);
            UpdateCommand = new UpdateMetadataCommand(this, progressManager);
            SaveCommand = new SaveMetadataCommand(this);
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProgressItem> Update()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
