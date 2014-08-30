using System.ComponentModel.DataAnnotations;
using PerfectMedia.UI.Properties;

namespace PerfectMedia.UI.Validations
{
    public class RatingAttribute : RangeAttribute
    {
        public RatingAttribute()
            : base(0d, 10d)
        {
            ErrorMessageResourceType = typeof(Resources);
            ErrorMessageResourceName = "InvalidRating";
        }
    }
}
