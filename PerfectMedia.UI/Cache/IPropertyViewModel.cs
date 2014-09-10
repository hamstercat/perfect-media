using System.ComponentModel;

namespace PerfectMedia.UI.Cache
{
    public interface IPropertyViewModel<T> : INotifyPropertyChanged
    {
        T Value { get; set; }
        T OriginalValue { get; }
        void Save();
    }
}