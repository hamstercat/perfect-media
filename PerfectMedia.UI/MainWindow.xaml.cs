using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using PerfectMedia.UI.Settings;

namespace PerfectMedia.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ShowSettings(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var settingsViewModel = (ISettingsViewModel)button.DataContext;
            var window = new SettingsWindow { DataContext = settingsViewModel };
            window.Show();
            await AsyncHelper.ExecuteEventHandlerTask(this, settingsViewModel.Initialize);
        }
    }
}
