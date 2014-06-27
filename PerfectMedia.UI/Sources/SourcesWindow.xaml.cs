using Ookii.Dialogs.Wpf;
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
using System.Windows.Shapes;
using FormsDialogResult = System.Windows.Forms.DialogResult;

namespace PerfectMedia.UI.Sources
{
    /// <summary>
    /// Interaction logic for SourcesWindow.xaml
    /// </summary>
    public partial class SourcesWindow : Window
    {
        private SourceManagerViewModel Sources
        {
            get
            {
                return ((ISourceProvider)DataContext).Sources;
            }
        }

        public SourcesWindow()
        {
            InitializeComponent();
        }

        private void AddRootFolder(object sender, RoutedEventArgs e)
        {
            VistaFolderBrowserDialog folderDialog = new VistaFolderBrowserDialog();
            bool? dialogResult = folderDialog.ShowDialog();
            if (dialogResult.GetValueOrDefault(false))
            {
                Sources.AddRootFolder(folderDialog.SelectedPath);
            }
        }

        private void RemoveRootFolder(object sender, RoutedEventArgs e)
        {
            string folderToRemove = (string)RootFoldersListView.SelectedItem;
            Sources.RemoveRootFolder(folderToRemove);
        }

        private void RefreshSpecificFolders(object sender, RoutedEventArgs e)
        {
            Sources.RefreshSpecificFolders();
        }

        private void AddSpecificFolder(object sender, RoutedEventArgs e)
        {
            VistaFolderBrowserDialog folderDialog = new VistaFolderBrowserDialog();
            bool? dialogResult = folderDialog.ShowDialog();
            if (dialogResult.GetValueOrDefault(false))
            {
                Sources.AddSpecificFolder(folderDialog.SelectedPath);
            }
        }

        private void RemoveSpecificFolder(object sender, RoutedEventArgs e)
        {
            string folderToRemove = (string)SpecificFoldersListView.SelectedItem;
            Sources.RemoveSpecificFolder(folderToRemove);
        }
    }
}
