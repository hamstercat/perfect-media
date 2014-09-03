using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PerfectMedia.UI
{
    public class SelectorExtenders : DependencyObject
    {
        public static bool GetIsAutoscroll(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsAutoscrollProperty);
        }

        public static void SetIsAutoscroll(DependencyObject obj, bool value)
        {
            obj.SetValue(IsAutoscrollProperty, value);
        }

        public static readonly DependencyProperty IsAutoscrollProperty =
            DependencyProperty.RegisterAttached("IsAutoscroll", typeof(bool), typeof(SelectorExtenders),
                new UIPropertyMetadata(default(bool), OnIsAutoscrollChanged));

        public static void OnIsAutoscrollChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            var value = (bool)e.NewValue;
            var listBox = (ListBox)s;
            ItemCollection items = listBox.Items;
            var sourceCollections = (INotifyCollectionChanged)items.SourceCollection;
            var autoscroller = new NotifyCollectionChangedEventHandler((s1, e1) =>
            {
                object selectedItem = null;
                switch (e1.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                    case NotifyCollectionChangedAction.Move:
                        selectedItem = e1.NewItems[e1.NewItems.Count - 1];
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        if (items.Count < e1.OldStartingIndex)
                        {
                            selectedItem = items[e1.OldStartingIndex - 1];
                        }
                        else if (items.Count > 0) selectedItem = items[0];
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        if (items.Count > 0) selectedItem = items[0];
                        break;
                }

                if (selectedItem != null)
                {
                    items.MoveCurrentTo(selectedItem);
                    listBox.ScrollIntoView(selectedItem);
                    FocusOnFirstTextBox(listBox, selectedItem);
                }
            });

            if (value)
            {
                sourceCollections.CollectionChanged += autoscroller;
            }
            else
            {
                sourceCollections.CollectionChanged -= autoscroller;
            }
        }

        private static void FocusOnFirstTextBox(ListBox listBox, object selectedItem)
        {
            var listBoxItem = (ListBoxItem)listBox.ItemContainerGenerator.ContainerFromItem(selectedItem);
            if (listBoxItem != null)
            {
                var firstTextBox = FindVisualChild<TextBox>(listBoxItem);
                firstTextBox.Focus();
            }
        }

        private static TChildItem FindVisualChild<TChildItem>(DependencyObject obj)
            where TChildItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is TChildItem)
                {
                    return (TChildItem)child;
                }
                var childOfChild = FindVisualChild<TChildItem>(child);
                if (childOfChild != null)
                {
                    return childOfChild;
                }
            }
            return null;
        }
    }
}
