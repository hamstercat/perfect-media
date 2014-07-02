using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.Progress
{
    public interface IProgressIndicator
    {
        void SetProgressManager(IProgressManagerViewModel viewModel);
    }
}
