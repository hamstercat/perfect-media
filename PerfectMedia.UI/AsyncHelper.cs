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
                string title = "An unhandled error has occured";
                string message = "This is most probably a bug. For more information about the error, please look at the logs.";
                await MahAppsDialogViewer.ShowMessageStatic(title, message);
            }
        }
    }
}
