using System.ComponentModel;

namespace PerfectMedia.UI.Cache
{
    public interface ICachedPropertyViewModel<T> : INotifyPropertyChanged
    {
        T Value { get; set; }
        T CachedValue { get; }
        void Save();
    }
}
