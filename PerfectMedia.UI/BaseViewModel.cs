using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace PerfectMedia.UI
{
    // Only used when Fody.PropertyChanged isn't enough
    public abstract class BaseViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IDictionary<string, string> _errors;

        protected BaseViewModel()
        {
            _errors = new Dictionary<string, string>();
        }

        public string this[string columnName]
        {
            get
            {
                string error;
                if (_errors.TryGetValue(columnName, out error))
                {
                    return error;
                }
                return null;
            }
        }

        public string Error { get; private set; }

        public bool IsValid
        {
            get { return _errors.All(err => string.IsNullOrEmpty(err.Value)); }
        }

        protected void OnPropertyChanged(string propertyName)
        {
#if DEBUG
            // Throw an exception when the property doesn't exist, helps when developping
            ValidatePropertyExists(propertyName);
#endif
            _errors[propertyName] = ValidateProperty(propertyName);
            RaisePropertyChanged(propertyName);
            RaisePropertyChanged("IsValid");
        }

        private void ValidatePropertyExists(string propertyName)
        {
            PropertyInfo property = GetType().GetProperty(propertyName);
            if (property == null)
            {
                throw new ArgumentException("Unknown property " + propertyName);
            }
        }

        private string ValidateProperty(string propertyName)
        {
            PropertyInfo property = GetType().GetProperty(propertyName);
            object value = property.GetValue(this);
            IEnumerable<string> errorInfos = property
                .GetCustomAttributes(true)
                .OfType<ValidationAttribute>()
                .Where(va => !va.IsValid(value))
                .Select(va => va.FormatErrorMessage(string.Empty));

            return errorInfos.FirstOrDefault();
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
