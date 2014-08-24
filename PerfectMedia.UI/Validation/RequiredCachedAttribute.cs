using System.ComponentModel.DataAnnotations;
using PerfectMedia.UI.Properties;

namespace PerfectMedia.UI.Validation
{
    public class RequiredCachedAttribute : LocalizedRequiredAttribute
    {
        public override bool IsValid(object value)
        {
            dynamic cachedProperty = value;
            object cachedValue = (object)cachedProperty.Value;
            return base.IsValid(cachedValue);
        }
    }
}
