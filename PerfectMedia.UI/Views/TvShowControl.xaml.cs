using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PerfectMedia.UI.Views
{
    /// <summary>
    /// Interaction logic for TvShowControl.xaml
    /// </summary>
    public partial class TvShowControl : UserControl
    {
        public TvShowControl()
        {
            InitializeComponent();
        }

        private void ShowSources(object sender, RoutedEventArgs e)
        {
            SourcesWindow sourcesWindow = new SourcesWindow();
            sourcesWindow.DataContext = DataContext;
            sourcesWindow.ShowDialog();
        }
    }
}
