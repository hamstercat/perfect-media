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

        public CachedPropertyViewModel(IKeyDataStore keyDataStore, string propertyKey, Func<T, string> converter, Func<string, T> otherConverter)
        {
            _keyDataStore = keyDataStore;
            _propertyKey = propertyKey;
            _converter = converter;
            _otherConverter = otherConverter;
        }

        private bool _valueLoaded;
        private T _value;
        public T Value
        {
            get
            {
                if (!_valueLoaded)
                {
                    string serializedValue = _keyDataStore.GetValue(_propertyKey);
                    if (!string.IsNullOrEmpty(serializedValue))
                    {
                        _value = _otherConverter(serializedValue);
                    }
                    _valueLoaded = true;
                }
                return _value;
            }
            set
            {
                _value = value;
                string serializedValue = _converter(_value);
                _keyDataStore.SetValue(_propertyKey, serializedValue);
            }
        }
    }
}
