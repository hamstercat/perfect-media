
namespace PerfectMedia.UI.Progress
{
    public class ProgressIndicatorFactory : IProgressIndicatorFactory
    {
        public IProgressIndicator CreateProgressIndicator()
        {
            return new ProgressWindow();
        }
    }
}
