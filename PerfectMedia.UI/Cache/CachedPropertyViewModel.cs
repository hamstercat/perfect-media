using System;
using PropertyChanged;

namespace PerfectMedia.UI.Cache
{
    [ImplementPropertyChanged]
    public abstract class CachedPropertyViewModel<T> : BaseViewModel, ICachedPropertyViewModel<T>
    {
        private readonly IKeyDataStore _keyDataStore;
        private readonly string _propertyKey;

        public T Value { get; set; }
        public T CachedValue { get; private set; }

        protected CachedPropertyViewModel(IKeyDataStore keyDataStore, string propertyKey)
        {
            _keyDataStore = keyDataStore;
            _propertyKey = propertyKey;
            InitializeValue();
        }

        protected abstract string ConvertToString(T item);
        protected abstract T ConvertFromString(string str);

        public void Save()
        {
            string serializedValue = ConvertToString(Value);
            _keyDataStore.SetValue(_propertyKey, serializedValue);
            CachedValue = Value;
        }

        private void InitializeValue()
        {
            string serializedValue = _keyDataStore.GetValue(_propertyKey);
            if (!string.IsNullOrEmpty(serializedValue))
            {
                Value = CachedValue = ConvertFromString(serializedValue);
            }
        }
    }
}
