using System.ComponentModel.DataAnnotations;
using PerfectMedia.UI.Properties;

namespace PerfectMedia.UI.Validation
{
    public class PositiveAttribute : RangeAttribute
    {
        public PositiveAttribute()
            : base(0, int.MaxValue)
        {
            ErrorMessageResourceType = typeof(Resources);
            ErrorMessageResourceName = "MustBePositive";
        }
    }
}
