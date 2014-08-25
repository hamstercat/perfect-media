using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace PerfectMedia.UI
{
    /// <summary>
    /// Base ViewModel when Fody.PropertyChanged isn't enough. Also allows data validation through ASP.NET MVC Data Annotations.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when the validation errors have changed for a property or for the entire entity.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private readonly IDictionary<string, string> _errors;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        protected BaseViewModel()
        {
            _errors = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets a value that indicates whether the entity has validation errors.
        /// </summary>
        public bool HasErrors
        {
            get { return _errors.Any(err => !string.IsNullOrEmpty(err.Value)); }
        }

        /// <summary>
        /// Gets the validation errors for a specified property or for the entire entity.
        /// </summary>
        /// <param name="propertyName">The name of the property to retrieve validation errors for; or null or <see cref="F:System.String.Empty" />, to retrieve entity-level errors.</param>
        /// <returns>
        /// The validation errors for the property or entity.
        /// </returns>
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

        /// <summary>
        /// Raises the PropertyChanged event for the given property and validate its value.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
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

        /// <summary>
        /// Validates the property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
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

        private void ValidatePropertyExists(string propertyName)
        {
            PropertyInfo property = GetType().GetProperty(propertyName);
            if (property == null)
            {
                throw new ArgumentException("Unknown property " + propertyName);
            }
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
            EventHandler<DataErrorsChangedEventArgs> handler = ErrorsChanged;
            if (handler != null)
            {
                handler(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }
    }
}
