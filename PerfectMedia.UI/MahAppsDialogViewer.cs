using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace PerfectMedia.UI
{
    public class MahAppsDialogViewer : IDialogViewer
    {
        public async Task ShowMessage(string title, string message)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            await metroWindow.ShowMessageAsync(title, message);
        }
    }
}
