using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Threading;

namespace PerfectMedia.UI
{
    public class BindableSelectedItemBehavior : Behavior<TreeView>
    {
        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(BindableSelectedItemBehavior), new UIPropertyMetadata(null, OnSelectedItemChanged));

        private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var matchingItem = FindTreeViewItem(sender, e);
            if (matchingItem != null)
            {
                SelectTreeViewItem(matchingItem);
            }
        }

        private static TreeViewItem FindTreeViewItem(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var self = (BindableSelectedItemBehavior)sender;
            TreeView treeView = self.AssociatedObject;
            return FindMatchingTreeViewItemInHierarchy(treeView, e.NewValue);
        }

        private static TreeViewItem FindMatchingTreeViewItemInHierarchy(ItemsControl items, object dataContext)
        {
            var treeViewItemToExpand = items as TreeViewItem;
            // WPF doesn't return the TreeViewItem if it hasn't been rendered yet, so force the update by expanding it and putting it back after
            bool isExpanded = ExpandTreeViewItem(treeViewItemToExpand);
            TreeViewItem result = FindTreeViewItemInChildren(items, dataContext);
            if (treeViewItemToExpand != null)
            {
                treeViewItemToExpand.IsExpanded = isExpanded;
            }
            return result;
        }

        private static TreeViewItem FindTreeViewItemInChildren(ItemsControl items, object dataContext)
        {
            items.UpdateLayout();
            foreach (object item in items.Items)
            {
                TreeViewItem treeViewItem = items.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
                if (treeViewItem != null)
                {
                    if (treeViewItem.DataContext == dataContext)
                    {
                        return treeViewItem;
                    }
                    TreeViewItem childTreeViewItem = FindMatchingTreeViewItemInHierarchy(treeViewItem, dataContext);
                    if (childTreeViewItem != null)
                    {
                        return childTreeViewItem;
                    }
                }
            }
            return null;
        }

        private static bool ExpandTreeViewItem(TreeViewItem treeViewItemToExpand)
        {
            bool isExpanded = false;
            if (treeViewItemToExpand != null)
            {
                isExpanded = treeViewItemToExpand.IsExpanded;
                treeViewItemToExpand.IsExpanded = true;
            }
            return isExpanded;
        }

        private static void SelectTreeViewItem(TreeViewItem matchingItem)
        {
            matchingItem.SetValue(TreeViewItem.IsSelectedProperty, true);
            var parent = ItemsControl.ItemsControlFromItemContainer(matchingItem) as TreeViewItem;
            if (parent != null)
            {
                parent.IsExpanded = true;
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectedItemChanged += OnTreeViewSelectedItemChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (AssociatedObject != null)
            {
                AssociatedObject.SelectedItemChanged -= OnTreeViewSelectedItemChanged;
            }
        }

        private void OnTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedItem = e.NewValue;
        }
    }
}
