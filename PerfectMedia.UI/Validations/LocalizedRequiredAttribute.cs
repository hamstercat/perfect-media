using System.ComponentModel.DataAnnotations;

namespace PerfectMedia.UI.Validations
{
    public class LocalizedRequiredAttribute : RequiredAttribute
    {
        public LocalizedRequiredAttribute()
        {
            ErrorMessageResourceType = typeof(ValidationsResources);
            ErrorMessageResourceName = "RequiredField";
        }
    }
}
