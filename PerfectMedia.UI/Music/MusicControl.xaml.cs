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
using PerfectMedia.UI.Sources;

namespace PerfectMedia.UI.Music
{
    /// <summary>
    /// Interaction logic for MusicControl.xaml
    /// </summary>
    public partial class MusicControl
    {
        public MusicControl()
        {
            InitializeComponent();
        }

        private void ShowSources(object sender, RoutedEventArgs e)
        {
            SourcesWindow sourcesWindow = new SourcesWindow { DataContext = DataContext };
            sourcesWindow.ShowDialog();
        }

        private async void MusicSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ITreeViewItemViewModel newItem = (ITreeViewItemViewModel)e.NewValue;
            await newItem.Load();
        }

        private async void MusicExpanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem treeViewItem = (TreeViewItem)e.OriginalSource;
            ITreeViewItemViewModel treeViewItemViewModel = (ITreeViewItemViewModel)treeViewItem.DataContext;
            await treeViewItemViewModel.LoadChildren();
        }
    }
}
