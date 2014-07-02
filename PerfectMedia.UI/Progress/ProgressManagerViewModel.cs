using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Progress
{
    [ImplementPropertyChanged]
    public class ProgressManagerViewModel : IProgressManagerViewModel
    {
        public ObservableCollection<ProgressItem> Total { get; set; }
        public ObservableCollection<ProgressItem> Completed { get; set; }
        public ObservableCollection<ProgressItem> InError { get; set; }
    }
}
