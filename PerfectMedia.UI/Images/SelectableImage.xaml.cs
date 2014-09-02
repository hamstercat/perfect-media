using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

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

        private async void HyperlinkClick(object sender, RoutedEventArgs e)
        {
            await AsyncHelper.ExecuteEventHandlerTask(this, async () =>
            {
                IImageViewModel images = await FindAvailableImages();
                ContentControl control = FindParentMainContentControl(this);
                images.OriginalContent = BindingOperations.GetBinding(control, ContentProperty);
                control.Content = images;
            });
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

        private async Task<IImageViewModel> FindAvailableImages()
        {
            IImageViewModel imageViewModel = (IImageViewModel)DataContext;
            await imageViewModel.LoadAvailableImages();
            return imageViewModel;
        }
    }
}
