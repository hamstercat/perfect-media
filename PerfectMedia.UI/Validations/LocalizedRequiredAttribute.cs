using System.ComponentModel.DataAnnotations;
using PerfectMedia.UI.Resources;

namespace PerfectMedia.UI.Validations
{
    public class LocalizedRequiredAttribute : RequiredAttribute
    {
        public LocalizedRequiredAttribute()
        {
            ErrorMessageResourceType = typeof(Validation);
            ErrorMessageResourceName = "RequiredField";
        }
    }
}
