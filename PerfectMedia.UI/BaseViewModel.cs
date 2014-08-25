using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace PerfectMedia.UI
{
    // Only used when Fody.PropertyChanged isn't enough
    public abstract class BaseViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private readonly IDictionary<string, string> _errors;

        protected BaseViewModel()
        {
            _errors = new Dictionary<string, string>();
        }

        public bool HasErrors
        {
            get { return _errors.Any(err => !string.IsNullOrEmpty(err.Value)); }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            propertyName = propertyName ?? string.Empty;
            string error;
            if (_errors.TryGetValue(propertyName, out error))
            {
                if (!string.IsNullOrEmpty(error))
                {
                    yield return error;
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
#if DEBUG
            // Throw an exception when the property doesn't exist, helps when developping
            ValidatePropertyExists(propertyName);
#endif
            _errors[propertyName] = ValidateProperty(propertyName);
            RaisePropertyChanged(propertyName);
            RaiseErrorsChanged(propertyName);
        }

        private void ValidatePropertyExists(string propertyName)
        {
            PropertyInfo property = GetType().GetProperty(propertyName);
            if (property == null)
            {
                throw new ArgumentException("Unknown property " + propertyName);
            }
        }

        protected virtual string ValidateProperty(string propertyName)
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

        private void RaiseErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
            {
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }
    }
}
