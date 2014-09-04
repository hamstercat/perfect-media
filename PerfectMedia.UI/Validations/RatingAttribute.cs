using System.ComponentModel.DataAnnotations;

namespace PerfectMedia.UI.Validations
{
    public class RatingAttribute : RangeAttribute
    {
        public RatingAttribute()
            : base(0d, 10d)
        {
            ErrorMessageResourceType = typeof(ValidationsResources);
            ErrorMessageResourceName = "InvalidRating";
        }
    }
}
