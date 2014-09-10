using System;
using System.Windows;
using System.Windows.Threading;
using Anotar.Log4Net;

namespace PerfectMedia.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DispatcherUnhandledException += OnUnhandledException;
        }

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

        private void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            LogTo.FatalException("Unhandled exception in application", e.Exception);
#pragma warning disable 4014
            // Fire and forget
            MahAppsDialogViewer.ShowMessageStatic(General.UnhandledException_Title, General.UnhandledException_Message);
#pragma warning restore 4014
            e.Handled = true;
        }
    }
}
