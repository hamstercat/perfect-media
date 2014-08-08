using System.Windows;

namespace PerfectMedia.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnExit(ExitEventArgs e)
        {
            ServiceLocator.DisposeInstances();
            base.OnExit(e);
        }
    }
}
