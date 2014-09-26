using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PerfectMedia.UI.Selection;

namespace PerfectMedia.UI.Movies.Selection
{
    /// <summary>
    /// Interaction logic for TvShowSelection.xaml
    /// </summary>
    public partial class MovieSelection : ICloseable
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
            var movieSelection = (ISelectionViewModel)DataContext;
            var originalBinding = (Binding)movieSelection.OriginalContent;
            BindingOperations.SetBinding(mainContentControl, ContentProperty, originalBinding);
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            CloseControl();
        }
    }
}
