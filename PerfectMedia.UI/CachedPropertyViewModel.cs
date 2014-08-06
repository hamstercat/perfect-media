using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI
{
    [ImplementPropertyChanged]
    public class CachedPropertyViewModel : BaseViewModel, ICachedPropertyViewModel
    {
        private readonly IKeyDataStore _keyDataStore;
        private readonly string _propertyKey;

        public CachedPropertyViewModel(IKeyDataStore keyDataStore, string propertyKey)
        {
            _keyDataStore = keyDataStore;
            _propertyKey = propertyKey;
        }

        private string _value;
        public string Value
        {
            get
            {
                if(string.IsNullOrEmpty(_value))
                {
                    _value = _keyDataStore.GetValue(_propertyKey);
                }
                return _value;
            }
            set
            {
                _value = value;
                _keyDataStore.SetValue(_propertyKey, value);
            }
        }
    }
}
