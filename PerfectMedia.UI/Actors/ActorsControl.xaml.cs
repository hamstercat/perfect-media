using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace PerfectMedia.UI.Actors
{
    /// <summary>
    /// Interaction logic for Actors.xaml
    /// </summary>
    public partial class ActorsControl
    {
        public ActorsControl()
        {
            InitializeComponent();
            DependencyPropertyDescriptor
                .FromProperty(ItemsControl.ItemsSourceProperty, typeof(ListView))
                .AddValueChanged(ActorsList, ActorsListSourceUpdate);
        }

        private void ActorsListSourceUpdate(object sender, EventArgs e)
        {
            ItemCollection items = ActorsList.Items;
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
                    ScrollToEnd();
                    FocusOnFirstTextBox(selectedItem);
                }
            });

            sourceCollections.CollectionChanged += autoscroller;
        }

        private void ScrollToEnd()
        {
            ControlTemplate template = ActorsList.Template;
            var scrollViewer = (ScrollViewer)template.FindName("ListViewScrollViewer", ActorsList);
            scrollViewer.ScrollToEnd();
        }

        private void FocusOnFirstTextBox(object selectedItem)
        {
            var listBoxItem = (ListBoxItem)ActorsList.ItemContainerGenerator.ContainerFromItem(selectedItem);
            if (listBoxItem != null)
            {
                var firstTextBox = FindVisualChild<TextBox>(listBoxItem);
                // TODO: make this work
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
