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

namespace PerfectMedia.UI.Images.Selection
{
    /// <summary>
    /// Interaction logic for VerticalImageSelection.xaml
    /// </summary>
    public partial class VerticalImageSelection : UserControl, ICloseable
    {
        private IImageSelectionViewModel ImageSelectionViewModel
        {
            get
            {
                return (IImageSelectionViewModel)DataContext;
            }
        }

        public VerticalImageSelection()
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
            BindingOperations.SetBinding(mainContentControl, ContentControl.ContentProperty, originalBinding);
        }
    }
}
