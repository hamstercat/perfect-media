using System;
using PropertyChanged;

namespace PerfectMedia.UI
{
    [ImplementPropertyChanged]
    public class CachedPropertyViewModel<T> : BaseViewModel, ICachedPropertyViewModel<T>
    {
        private readonly IKeyDataStore _keyDataStore;
        private readonly string _propertyKey;
        private readonly Func<T, string> _converter;
        private readonly Func<string, T> _otherConverter;

        public T Value { get; set; }
        public T CachedValue { get; private set; }

        public CachedPropertyViewModel(IKeyDataStore keyDataStore, string propertyKey, Func<T, string> converter, Func<string, T> otherConverter)
        {
            _keyDataStore = keyDataStore;
            _propertyKey = propertyKey;
            _converter = converter;
            _otherConverter = otherConverter;
            InitializeValue();
        }

        public void Save()
        {
            string serializedValue = _converter(Value);
            _keyDataStore.SetValue(_propertyKey, serializedValue);
            CachedValue = Value;
        }

        private void InitializeValue()
        {
            string serializedValue = _keyDataStore.GetValue(_propertyKey);
            if (!string.IsNullOrEmpty(serializedValue))
            {
                Value = CachedValue = _otherConverter(serializedValue);
            }
        }
    }
}
