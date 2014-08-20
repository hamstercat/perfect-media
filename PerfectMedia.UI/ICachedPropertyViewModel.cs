using System.ComponentModel;

namespace PerfectMedia.UI
{
    public interface ICachedPropertyViewModel<T> : INotifyPropertyChanged
    {
        T Value { get; set; }
        void Save();
    }
}
