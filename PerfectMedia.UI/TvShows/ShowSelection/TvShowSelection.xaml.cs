﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
            BindingOperations.SetBinding(mainContentControl, ContentProperty, originalBinding);
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            CloseControl();
        }
    }
}
