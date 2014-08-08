using System.Windows;

namespace PerfectMedia.UI
{
    public class IsClosedAttachedBehavior
    {
        public static DependencyProperty IsClosedViewProperty = DependencyProperty.RegisterAttached("IsClosedView", typeof(bool), typeof(IsClosedAttachedBehavior), new UIPropertyMetadata(false, OnIsClosedView));

        public static bool GetIsClosedView(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsClosedViewProperty);
        }

        public static void SetIsClosedView(DependencyObject obj, bool value)
        {
            obj.SetValue(IsClosedViewProperty, value);
        }

        public static void OnIsClosedView(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ICloseable closeable = (ICloseable)d;
            if ((bool)e.NewValue)
            {
                closeable.CloseControl();
            }
        }
    }
}
