using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
#if DEBUG
            // Throw an exception when the property doesn't exist, helps when developping
            PropertyInfo property = GetType().GetProperty(propertyName);
            if (property == null)
            {
                throw new ArgumentException("Unknown property " + propertyName);
            }
#endif
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
