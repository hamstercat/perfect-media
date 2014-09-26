using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PerfectMedia.UI.Selection;

namespace PerfectMedia.UI.Music.Albums.Selection
{
    /// <summary>
    /// Interaction logic for AlbumSelection.xaml
    /// </summary>
    public partial class AlbumSelection : ICloseable
    {
        public AlbumSelection()
        {
            InitializeComponent();
        }

        public void CloseControl()
        {
            ContentControl mainContentControl = MainContentHelper.GetParentMainContentControl(this);
            RestoreInitialBinding(mainContentControl);
        }

        private void RestoreInitialBinding(ContentControl mainContentControl)
        {
            var tvShowSelection = (ISelectionViewModel)DataContext;
            var originalBinding = (Binding)tvShowSelection.OriginalContent;
            BindingOperations.SetBinding(mainContentControl, ContentProperty, originalBinding);
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            CloseControl();
        }
    }
}
