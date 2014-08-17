using System;
using System.Windows;

namespace PerfectMedia.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            ServiceLocator.InitializeInstances();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            ServiceLocator.UninitializeInstances();
            base.OnExit(e);
        }
    }
}
