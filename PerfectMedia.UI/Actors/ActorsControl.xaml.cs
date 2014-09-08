using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Anotar.Log4Net;

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
#pragma warning disable 4014
                    // Fire and forget
                    AsyncHelper.ExecuteEventHandlerTask(this, () => FocusOnFirstTextBox(selectedItem));
#pragma warning restore 4014
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

        private async Task FocusOnFirstTextBox(object selectedItem)
        {
            var listBoxItem = (ListBoxItem)ActorsList.ItemContainerGenerator.ContainerFromItem(selectedItem);
            if (listBoxItem != null)
            {
                TextBox firstTextBox = await FindFirstTextBox(listBoxItem);
                if (firstTextBox != null)
                {
                    firstTextBox.Focus();
                }
            }
        }

        private static async Task<TextBox> FindFirstTextBox(ListBoxItem listBoxItem)
        {
            var firstTextBox = FindVisualChild<TextBox>(listBoxItem);
            int loopCount = 0;
            // This loop is required as FindVisualChild returns null until the item has been generated
            while(firstTextBox == null)
            {
                await Task.Delay(10);
                firstTextBox = FindVisualChild<TextBox>(listBoxItem);
                if (loopCount++ == 100)
                {
                    LogTo.Error("We've waited more than 1 second, still can't find the textbox to focus");
                    break;
                }
            }
            return firstTextBox;
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
