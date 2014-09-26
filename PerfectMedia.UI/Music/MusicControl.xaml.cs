using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PerfectMedia.UI.Music.Albums;
using PerfectMedia.UI.Music.Artists;
using PerfectMedia.UI.Selection;
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
            var sourcesWindow = new SourcesWindow { DataContext = DataContext };
            sourcesWindow.ShowDialog();
        }

        private void ShowArtistSelection(object sender, RoutedEventArgs e)
        {
            object originalContent = BindingOperations.GetBinding(MainContentControl, ContentProperty);
            ISelectionViewModel tvShow = GetArtistViewModel(sender);
            tvShow.OriginalContent = originalContent;
            tvShow.IsClosed = false;
            MainContentControl.Content = tvShow;
        }

        private ISelectionViewModel GetArtistViewModel(object sender)
        {
            var frameworkElement = (FrameworkElement)sender;
            var artist = (IArtistViewModel)frameworkElement.DataContext;
            return artist.Selection;
        }

        private void ShowAlbumSelection(object sender, RoutedEventArgs e)
        {
            object originalContent = BindingOperations.GetBinding(MainContentControl, ContentProperty);
            ISelectionViewModel tvShow = GetAlbumViewModel(sender);
            tvShow.OriginalContent = originalContent;
            tvShow.IsClosed = false;
            MainContentControl.Content = tvShow;
        }

        private ISelectionViewModel GetAlbumViewModel(object sender)
        {
            var frameworkElement = (FrameworkElement)sender;
            var album = (IAlbumViewModel)frameworkElement.DataContext;
            return album.Selection;
        }

        private async void MusicSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            await AsyncHelper.ExecuteEventHandlerTask(this, async () =>
            {
                var newItem = (ITreeViewItemViewModel)e.NewValue;
                await newItem.Load();
            });
        }

        private async void MusicExpanded(object sender, RoutedEventArgs e)
        {
            await AsyncHelper.ExecuteEventHandlerTask(this, async () =>
            {
                var treeViewItem = (TreeViewItem)e.OriginalSource;
                var treeViewItemViewModel = (ITreeViewItemViewModel)treeViewItem.DataContext;
                await treeViewItemViewModel.LoadChildren();
            });
        }
    }
}
