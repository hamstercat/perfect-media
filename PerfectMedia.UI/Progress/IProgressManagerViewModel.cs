using System.Threading.Tasks;

namespace PerfectMedia.UI.Progress
{
    public interface IProgressManagerViewModel
    {
        void AddItem(ProgressItem item);
        Task Start();
    }
}
