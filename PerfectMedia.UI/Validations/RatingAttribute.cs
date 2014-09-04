using System.ComponentModel.DataAnnotations;
using PerfectMedia.UI.Resources;

namespace PerfectMedia.UI.Validations
{
    public class RatingAttribute : RangeAttribute
    {
        public RatingAttribute()
            : base(0d, 10d)
        {
            ErrorMessageResourceType = typeof(Validation);
            ErrorMessageResourceName = "InvalidRating";
        }
    }
}
