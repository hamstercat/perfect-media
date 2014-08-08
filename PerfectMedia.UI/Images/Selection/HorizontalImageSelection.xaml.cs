using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PerfectMedia.UI.Images.Selection
{
    /// <summary>
    /// Interaction logic for HorizontalImageSelection.xaml
    /// </summary>
    public partial class HorizontalImageSelection : UserControl, ICloseable
    {
        private IImageSelectionViewModel ImageSelectionViewModel
        {
            get
            {
                return (IImageSelectionViewModel)DataContext;
            }
        }

        public HorizontalImageSelection()
        {
            InitializeComponent();
        }

        public void CloseControl()
        {
            ContentControl parent = MainContentHelper.GetParentMainContentControl(this);
            RestoreInitialBinding(parent);
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            CloseControl();
        }

        private void ChooseFileClick(object sender, RoutedEventArgs e)
        {
            ChooseImageFileWindow chooseImage = new ChooseImageFileWindow();
            chooseImage.Owner = Window.GetWindow(this);
            chooseImage.DataContext = ImageSelectionViewModel.Download;
            chooseImage.ShowDialog();
        }

        private void RestoreInitialBinding(ContentControl mainContentControl)
        {
            Binding originalBinding = (Binding)ImageSelectionViewModel.OriginalContent;
            BindingOperations.SetBinding(mainContentControl, ContentProperty, originalBinding);
        }
    }
}
