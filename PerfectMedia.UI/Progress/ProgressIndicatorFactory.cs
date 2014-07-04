using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Progress
{
    public class ProgressIndicatorFactory : IProgressIndicatorFactory
    {
        public IProgressIndicator CreateProgressIndicator()
        {
            return new ProgressWindow();
        }
    }
}
