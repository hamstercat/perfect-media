using System;
using System.Threading.Tasks;
using Anotar.Log4Net;

namespace PerfectMedia.UI
{
    internal static class AsyncHelper
    {
        public static async Task ExecuteEventHandlerTask(object caller, Func<Task> func)
        {
            Exception exception = null;
            try
            {
                await func();
            }
            catch (Exception ex)
            {
                exception = ex;
                LogTo.ErrorException("Unhandled exception in async method " + caller.GetType().FullName, ex);
            }
            await ShowUnhandledExceptionMessage(exception);
        }

        private static async Task ShowUnhandledExceptionMessage(Exception exception)
        {
            if (exception != null)
            {
                await MahAppsDialogViewer.ShowMessageStatic(General.UnhandledException_Title, General.UnhandledException_Message);
            }
        }
    }
}
