using System;
using PerfectMedia.UI.Validations;
using PropertyChanged;

namespace PerfectMedia.UI.Cache
{
    [ImplementPropertyChanged]
    public abstract class CachedPropertyDecorator<T> : PropertyDecorator<T>
    {
        private readonly IKeyDataStore _keyDataStore;
        private readonly string _propertyKey;

        protected CachedPropertyDecorator(IKeyDataStore keyDataStore, string propertyKey)
            : base(new PropertyViewModel<T>())
        {
            _keyDataStore = keyDataStore;
            _propertyKey = propertyKey;
            InitializeValue();
        }

        protected abstract string ConvertToString(T item);
        protected abstract T ConvertFromString(string str);

        public override void Save()
        {
            string serializedValue = ConvertToString(Value);
            _keyDataStore.SetValue(_propertyKey, serializedValue);
            base.Save();
        }

        private void InitializeValue()
        {
            string serializedValue = _keyDataStore.GetValue(_propertyKey);
            if (!string.IsNullOrEmpty(serializedValue))
            {
                Value = ConvertFromString(serializedValue);
                base.Save();
            }
        }
    }
}
