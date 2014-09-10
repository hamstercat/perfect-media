using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace PerfectMedia.UI.Cache
{
    [ImplementPropertyChanged]
    public class PropertyViewModel<T> : BaseViewModel, IPropertyViewModel<T>
    {
        public T Value { get; set; }
        public T OriginalValue { get; private set; }

        public PropertyViewModel()
            : this(default(T))
        { }

        public PropertyViewModel(T value)
        {
            OriginalValue = Value = value;
        }

        public void Save()
        {
            OriginalValue = Value;
        }
    }
}
