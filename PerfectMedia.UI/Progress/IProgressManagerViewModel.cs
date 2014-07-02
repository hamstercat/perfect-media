using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.Progress
{
    public interface IProgressManagerViewModel
    {
        ObservableCollection<ProgressItem> Total { get; set; }
    }
}
