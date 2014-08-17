using System;

namespace PerfectMedia.UI.Busy
{
    public interface IBusyProvider
    {
        bool IsBusy { get; }
        IDisposable DoWork();
    }
}
