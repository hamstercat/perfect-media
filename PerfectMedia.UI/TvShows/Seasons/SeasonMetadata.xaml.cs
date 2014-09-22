using System.Diagnostics;
using System.Windows;

namespace PerfectMedia.UI.TvShows.Seasons
{
    /// <summary>
    /// Interaction logic for SeasonMetadata.xaml
    /// </summary>
    public partial class SeasonMetadata
    {
        public SeasonMetadata()
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
