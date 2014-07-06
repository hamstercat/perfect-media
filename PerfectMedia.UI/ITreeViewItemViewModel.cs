using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI
{
    public interface ITreeViewItemViewModel
    {
        string DisplayName { get; }
        bool IsExpanded { get; set; }
    }
}
