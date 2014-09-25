using System.Diagnostics;
using System.Windows;

namespace PerfectMedia.UI.Music.Artists
{
    /// <summary>
    /// Interaction logic for ArtistGeneralInformation.xaml
    /// </summary>
    public partial class ArtistGeneralInformation
    {
        public ArtistGeneralInformation()
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
