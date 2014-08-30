using System.ComponentModel.DataAnnotations;
using PerfectMedia.UI.Properties;

namespace PerfectMedia.UI.Validations
{
    public class LocalizedRequiredAttribute : RequiredAttribute
    {
        public LocalizedRequiredAttribute()
        {
            ErrorMessageResourceType = typeof(Resources);
            ErrorMessageResourceName = "RequiredField";
        }
    }
}
