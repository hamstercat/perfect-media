using System.ComponentModel.DataAnnotations;
using PerfectMedia.UI.Properties;

namespace PerfectMedia.UI.Validation
{
    public class RequiredCachedAttribute : RequiredAttribute
    {
        public RequiredCachedAttribute()
        {
            ErrorMessageResourceType = typeof(Resources);
            ErrorMessageResourceName = "RequiredField";
        }

        public override bool IsValid(object value)
        {
            dynamic cachedProperty = value;
            object cachedValue = (object)cachedProperty.Value;
            return base.IsValid(cachedValue);
        }
    }
}
