using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI
{
    public interface ICachedPropertyViewModel<T> : INotifyPropertyChanged
    {
        T Value { get; set; }
    }
}
