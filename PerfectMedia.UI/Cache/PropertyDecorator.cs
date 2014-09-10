using System;
using System.ComponentModel;
using PropertyChanged;

namespace PerfectMedia.UI.Cache
{
    [ImplementPropertyChanged]
    public abstract class PropertyDecorator<T> : BaseViewModel, IPropertyViewModel<T>
    {
        private readonly IPropertyViewModel<T> _property;

        public virtual T Value
        {
            get { return _property.Value; }
            set { _property.Value = value; }
        }

        public virtual T OriginalValue
        {
            get { return _property.OriginalValue; }
        }

        protected PropertyDecorator(IPropertyViewModel<T> property)
        {
            _property = property;
            _property.PropertyChanged += PropertyViewModelPropertyChanged;
        }

        public virtual void Save()
        {
            _property.Save();
        }

        private void PropertyViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value" || e.PropertyName == "OriginalValue")
            {
                OnPropertyChanged(e.PropertyName);
            }
        }
    }
}
