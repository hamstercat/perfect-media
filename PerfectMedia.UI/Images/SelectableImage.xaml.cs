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
        public static readonly DependencyProperty ContainerControlProperty = DependencyProperty.Register("ContainerControl", typeof(ContentControl), typeof(SelectableImage));
        public ContentControl ContainerControl
        {
            get { return (ContentControl)base.GetValue(ContainerControlProperty); }
            set { base.SetValue(ContainerControlProperty, value); }
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

        private void HyperlinkClick(object sender, RoutedEventArgs e)
        {
            RefreshAvailableImages();
            ContainerControl.Content = CreateImageSelectionControl();
        }

        private void RefreshAvailableImages()
        {
            IImageViewModel imageViewModel = (IImageViewModel)DataContext;
            imageViewModel.LoadAvailableImages();
        }

        private ImageSelection CreateImageSelectionControl()
        {
            ImageSelection imageSelection = new ImageSelection();
            imageSelection.DataContext = DataContext;
            imageSelection.OriginalContent = (Control)ContainerControl.Content;
            return imageSelection;
        }
    }
}
