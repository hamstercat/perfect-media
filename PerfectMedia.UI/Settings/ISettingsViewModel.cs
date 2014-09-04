using System.ComponentModel;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Settings
{
    public interface ISettingsViewModel : INotifyPropertyChanged
    {
        bool HasErrors { get; }
        Task Initialize();
        void Save();
    }
}
