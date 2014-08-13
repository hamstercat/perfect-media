using System.Windows;
using System.Windows.Forms;

namespace PerfectMedia.UI.Images.Selection
{
    /// <summary>
    /// Interaction logic for DownloadImageWindow.xaml
    /// </summary>
    public partial class ChooseImageFileWindow : ICloseable
    {
        public ChooseImageFileWindow()
        {
            InitializeComponent();
        }

        public void CloseControl()
        {
            Close();
        }

        private void BrowseClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            DialogResult result = fileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Url.Text = fileDialog.FileName;
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            ChooseImageFileViewModel downloadImageViewModel = (ChooseImageFileViewModel)DataContext;
            downloadImageViewModel.Url = null;
            Close();
        }
    }
}
