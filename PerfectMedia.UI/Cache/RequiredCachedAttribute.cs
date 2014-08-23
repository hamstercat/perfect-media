using System.ComponentModel.DataAnnotations;

namespace PerfectMedia.UI.Cache
{
    public class RequiredCachedAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            dynamic cachedProperty = value;
            object cachedValue = (object)cachedProperty.Value;
            return base.IsValid(cachedValue);
        }
    }
}
