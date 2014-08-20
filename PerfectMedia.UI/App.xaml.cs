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
            // TODO: show generic message to user and prompt them to send the log
        }
    }
}
