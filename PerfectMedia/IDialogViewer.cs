using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia
{
    public interface IDialogViewer
    {
        Task ShowMessage(string title, string message);
    }
}
