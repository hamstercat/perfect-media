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
    public partial class SelectableImage
    {
        /// <summary>
        /// The WidthRatio dependency property.
        /// </summary>
        public static readonly DependencyProperty WidthRatioProperty = DependencyProperty.Register("WidthRatio", typeof(double), typeof(SelectableImage), null);

        /// <summary>
        /// Gets or sets the width ratio.
        /// </summary>
        public double WidthRatio
        {
            get { return (double)GetValue(WidthRatioProperty); }
            set { SetValue(WidthRatioProperty, value); }
        }

        /// <summary>
        /// The HeightRatio dependency property.
        /// </summary>
        public static readonly DependencyProperty HeightRatioProperty = DependencyProperty.Register("HeightRatio", typeof(double), typeof(SelectableImage), null);

        /// <summary>
        /// Gets or sets the height ratio.
        /// </summary>
        public double HeightRatio
        {
            get { return (double)GetValue(HeightRatioProperty); }
            set { SetValue(HeightRatioProperty, value); }
        }

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
