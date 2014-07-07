using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PerfectMedia.UI.Images
{
    /// <summary>
    /// Interaction logic for DownloadImageWindow.xaml
    /// </summary>
    public partial class ChooseImageFileWindow : Window, ICloseable
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
