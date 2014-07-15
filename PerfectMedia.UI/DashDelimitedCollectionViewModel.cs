using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI
{
    public class DashDelimitedCollectionViewModel<T> : BaseViewModel
    {
        private readonly Func<string, T> _mapStringToItem;

        public SmartObservableCollection<T> Collection { get; private set; }

        public string String
        {
            get
            {
                return string.Join(" / ", Collection);
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Collection.Clear();
                }
                else
                {
                    TransformStringToCollection(value);
                }
            }
        }

        public DashDelimitedCollectionViewModel(Func<string,T> mapStringToItem)
        {
            _mapStringToItem = mapStringToItem;
            Collection = new SmartObservableCollection<T>();
            Collection.CollectionChanged += CollectionChanged;
        }

        public void ReplaceWith(IEnumerable<T> items)
        {
            Collection.Clear();
            foreach (T item in items)
            {
                Collection.Add(item);
            }
        }

        private void TransformStringToCollection(string value)
        {
            Collection.Clear();
            IEnumerable<string> splittedItems = value.Split('/');
            foreach (string item in splittedItems)
            {
                string trimmedItem = item.Trim();
                if (!string.IsNullOrEmpty(trimmedItem))
                {
                    T itemToAdd = _mapStringToItem(trimmedItem);
                    Collection.Add(itemToAdd);
                }
            }
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("String");
        }
    }
}
