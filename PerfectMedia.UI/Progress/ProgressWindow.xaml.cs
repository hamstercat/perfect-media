﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using System.Windows.Shapes;

namespace PerfectMedia.UI.Progress
{
    /// <summary>
    /// Interaction logic for ProgressWindow.xaml
    /// </summary>
    public partial class ProgressWindow : Window, IProgressIndicator
    {
        public ProgressWindow()
        {
            InitializeComponent();
        }

        public void SetProgressManager(IProgressManagerViewModel viewModel)
        {
            DataContext = viewModel;
            viewModel.Total.CollectionChanged += ProgressItemCollectionChanged;
        }

        private void ProgressItemCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (Visibility != Visibility.Visible)
            {
                ShowDialog();
            }
        }
    }
}
