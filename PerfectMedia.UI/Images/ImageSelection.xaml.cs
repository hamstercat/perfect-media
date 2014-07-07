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

namespace PerfectMedia.UI.Images
{
    /// <summary>
    /// Interaction logic for ImageSelection.xaml
    /// </summary>
    public partial class ImageSelection : UserControl, ICloseable
    {
        private IImageViewModel ImageViewModel
        {
            get
            {
                return (IImageViewModel)DataContext;
            }
        }

        public ImageSelection()
        {
            InitializeComponent();
        }

        public void CloseControl()
        {
            ContentControl parent = GetParentContentControl(this);
            Binding originalBinding = FindOriginalContent();
            BindingOperations.SetBinding(parent, ContentControl.ContentProperty, originalBinding);
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            CloseControl();
        }

        private void ChooseFileClick(object sender, RoutedEventArgs e)
        {
            ChooseImageFileWindow chooseImage = new ChooseImageFileWindow();
            chooseImage.Owner = Window.GetWindow(this);
            chooseImage.DataContext = ImageViewModel.Download;
            chooseImage.ShowDialog();
        }

        private ContentControl GetParentContentControl(DependencyObject dependencyObject)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(dependencyObject);
            if (IsMainContentControl(parent))
            {
                return (ContentControl)parent;
            }
            return GetParentContentControl(parent);
        }

        private bool IsMainContentControl(DependencyObject parent)
        {
            ContentControl control = parent as ContentControl;
            return control != null && control.Name == "MainContentControl";
        }

        private Binding FindOriginalContent()
        {
            return (Binding)ImageViewModel.OriginalContent;
        }
    }
}
