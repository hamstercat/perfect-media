using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.ViewModels
{
    public interface IMetadataProvider
    {
        void Refresh();
        void Update();
        void Save();
    }
}
