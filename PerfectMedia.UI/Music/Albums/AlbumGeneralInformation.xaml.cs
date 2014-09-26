using System.Diagnostics;
using System.Windows;

namespace PerfectMedia.UI.Music.Albums
{
    /// <summary>
    /// Interaction logic for AlbumGeneralInformation.xaml
    /// </summary>
    public partial class AlbumGeneralInformation
    {
        public AlbumGeneralInformation()
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
