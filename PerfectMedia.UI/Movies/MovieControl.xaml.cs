﻿using PerfectMedia.UI.Sources;
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

namespace PerfectMedia.UI.Movies
{
    /// <summary>
    /// Interaction logic for MovieControl.xaml
    /// </summary>
    public partial class MovieControl : UserControl
    {
        public MovieControl()
        {
            InitializeComponent();
        }

        private void ShowSources(object sender, RoutedEventArgs e)
        {
            SourcesWindow sourcesWindow = new SourcesWindow();
            sourcesWindow.DataContext = DataContext;
            sourcesWindow.ShowDialog();
        }

        /*private void ShowTvShowSelection(object sender, RoutedEventArgs e)
        {
            object originalContent = BindingOperations.GetBinding(MainContentControl, ContentControl.ContentProperty);
            ITvShowViewModel tvShow = GetTvShowViewModel(sender);
            tvShow.Selection.OriginalContent = originalContent;
            tvShow.Selection.IsClosed = false;
            MainContentControl.Content = tvShow.Selection;
        }

        private ITvShowViewModel GetTvShowViewModel(object sender)
        {
            FrameworkElement frameworkElement = (FrameworkElement)sender;
            return (ITvShowViewModel)frameworkElement.DataContext;
        }*/
    }
}
