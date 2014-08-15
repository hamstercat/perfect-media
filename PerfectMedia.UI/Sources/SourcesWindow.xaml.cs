using System.Windows;
using Ookii.Dialogs.Wpf;

namespace PerfectMedia.UI.Sources
{
    /// <summary>
    /// Interaction logic for SourcesWindow.xaml
    /// </summary>
    public partial class SourcesWindow
    {
        private ISourceManagerViewModel Sources
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

        private async void RefreshSpecificFolders(object sender, RoutedEventArgs e)
        {
            await Sources.RefreshSpecificFolders();
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
