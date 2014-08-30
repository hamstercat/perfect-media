using System;
using PerfectMedia.UI.Validations;
using PropertyChanged;

namespace PerfectMedia.UI.Cache
{
    [ImplementPropertyChanged]
    public abstract class CachedPropertyViewModel<T> : BaseViewModel, ICachedPropertyViewModel<T>
    {
        private readonly IKeyDataStore _keyDataStore;
        private readonly string _propertyKey;
        private readonly bool _isRequired;

        [LocalizedRequired]
        public T Value { get; set; }

        public T CachedValue { get; private set; }

        protected CachedPropertyViewModel(IKeyDataStore keyDataStore, string propertyKey, bool isRequired)
        {
            _keyDataStore = keyDataStore;
            _propertyKey = propertyKey;
            _isRequired = isRequired;
            InitializeValue();
        }

        protected abstract string ConvertToString(T item);
        protected abstract T ConvertFromString(string str);

        protected override string ValidateProperty(string propertyName)
        {
            if (_isRequired)
            {
                return base.ValidateProperty(propertyName);
            }
            return string.Empty;
        }

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
