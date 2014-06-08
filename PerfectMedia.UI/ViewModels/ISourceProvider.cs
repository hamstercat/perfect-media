using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.ViewModels
{
    public interface ISourceProvider
    {
        SourceManagerViewModel Sources { get; }
    }
}
