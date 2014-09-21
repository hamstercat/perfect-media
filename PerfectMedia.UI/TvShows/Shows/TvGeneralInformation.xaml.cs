using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace PerfectMedia.UI.TvShows.Shows
{
    /// <summary>
    /// Interaction logic for TvGeneralInformation.xaml
    /// </summary>
    public partial class TvGeneralInformation
    {
        public TvGeneralInformation()
        {
            InitializeComponent();
        }

        private void PathHyperlinkClick(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            string path = Path.Text;
            Process.Start(path);
        }
    }
}
