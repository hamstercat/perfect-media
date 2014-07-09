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

namespace PerfectMedia.UI.TvShows.ShowSelection
{
    /// <summary>
    /// Interaction logic for TvShowSelection.xaml
    /// </summary>
    public partial class TvShowSelection : UserControl, ICloseable
    {
        public TvShowSelection()
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
            ITvShowSelectionViewModel tvShowSelection = (ITvShowSelectionViewModel)DataContext;
            Binding originalBinding = (Binding)tvShowSelection.OriginalContent;
            BindingOperations.SetBinding(mainContentControl, ContentControl.ContentProperty, originalBinding);
        }
    }
}
