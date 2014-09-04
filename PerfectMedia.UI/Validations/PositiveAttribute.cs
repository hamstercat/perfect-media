using System.ComponentModel.DataAnnotations;

namespace PerfectMedia.UI.Validations
{
    public class PositiveAttribute : RangeAttribute
    {
        public PositiveAttribute()
            : base(0, int.MaxValue)
        {
            ErrorMessageResourceType = typeof(ValidationsResources);
            ErrorMessageResourceName = "MustBePositive";
        }
    }
}
