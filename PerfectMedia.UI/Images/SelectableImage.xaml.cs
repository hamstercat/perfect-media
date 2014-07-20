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
    /// Interaction logic for SelectableImage.xaml
    /// </summary>
    public partial class SelectableImage : UserControl
    {
        public SelectableImage()
        {
            InitializeComponent();
        }

        private void GridMouseEnter(object sender, MouseEventArgs e)
        {
            ChangeMouseOverOverlayVisibility(Visibility.Visible);
        }

        private void GridMouseLeave(object sender, MouseEventArgs e)
        {
            ChangeMouseOverOverlayVisibility(Visibility.Hidden);
        }

        private void ChangeMouseOverOverlayVisibility(Visibility visibility)
        {
            MouseOverOverlay.Visibility = visibility;
        }

        private void HyperlinkClick(object sender, RoutedEventArgs e)
        {
            IImageViewModel images = FindAvailableImages();
            ContentControl control = FindParentMainContentControl(this);
            images.OriginalContent = BindingOperations.GetBinding(control, ContentControl.ContentProperty);
            control.Content = images;
        }

        private ContentControl FindParentMainContentControl(FrameworkElement frameworkElement)
        {
            if (frameworkElement.Name == "MainContentControl")
            {
                return (ContentControl)frameworkElement;
            }
            FrameworkElement parent = (FrameworkElement)VisualTreeHelper.GetParent(frameworkElement);
            return FindParentMainContentControl(parent);
        }

        private IImageViewModel FindAvailableImages()
        {
            IImageViewModel imageViewModel = (IImageViewModel)DataContext;
            imageViewModel.LoadAvailableImages();
            return imageViewModel;
        }
    }
}
