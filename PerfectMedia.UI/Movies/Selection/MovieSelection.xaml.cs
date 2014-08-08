using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PerfectMedia.UI.Movies.Selection
{
    /// <summary>
    /// Interaction logic for TvShowSelection.xaml
    /// </summary>
    public partial class MovieSelection : UserControl, ICloseable
    {
        public MovieSelection()
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
            IMovieSelectionViewModel movieSelection = (IMovieSelectionViewModel)DataContext;
            Binding originalBinding = (Binding)movieSelection.OriginalContent;
            BindingOperations.SetBinding(mainContentControl, ContentProperty, originalBinding);
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            CloseControl();
        }
    }
}
