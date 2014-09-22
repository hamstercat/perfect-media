using System.Diagnostics;
using System.Windows;

namespace PerfectMedia.UI.Movies
{
    /// <summary>
    /// Interaction logic for GeneralInformation.xaml
    /// </summary>
    public partial class GeneralInformation
    {
        public GeneralInformation()
        {
            InitializeComponent();
        }

        private void PathHyperlinkClick(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            string args = string.Format("/select,\"{0}\"", Path.Text);
            Process.Start("explorer", args);
        }
    }
}
