using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PerfectMedia.UI
{
    internal static class MainContentHelper
    {
        internal static ContentControl GetParentMainContentControl(DependencyObject dependencyObject)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(dependencyObject);
            if (IsMainContentControl(parent))
            {
                return (ContentControl)parent;
            }
            return GetParentMainContentControl(parent);
        }

        private static bool IsMainContentControl(DependencyObject parent)
        {
            ContentControl control = parent as ContentControl;
            return control != null && control.Name == "MainContentControl";
        }
    }
}
