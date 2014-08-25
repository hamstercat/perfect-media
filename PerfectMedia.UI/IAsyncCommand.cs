using System.Threading.Tasks;
using System.Windows.Input;

namespace PerfectMedia.UI
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}