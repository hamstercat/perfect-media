namespace PerfectMedia.UI.Validations
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
