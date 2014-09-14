using System;
using System.Threading.Tasks;
using Anotar.Log4Net;
using PerfectMedia.ExternalApi;

namespace PerfectMedia.UI
{
    internal static class AsyncHelper
    {
        public static async Task ExecuteEventHandlerTask(object caller, Func<Task> func)
        {
            string title = null;
            string message = null;
            try
            {
                await func();
            }
            catch (NoInternetConnectionException)
            {
                title = General.NoInternetConnection_Title;
                message = General.NoInternetConnection_Message;
            }
            catch (Exception ex)
            {
                LogTo.ErrorException("Unhandled exception in async method " + caller.GetType().FullName, ex);
                title = General.UnhandledException_Title;
                message = General.UnhandledException_Message;
            }
            await ShowUnhandledExceptionMessage(title, message);
        }

        private static async Task ShowUnhandledExceptionMessage(string title, string message)
        {
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(message))
            {
                await MahAppsDialogViewer.ShowMessageStatic(title, message);
            }
        }
    }
}
