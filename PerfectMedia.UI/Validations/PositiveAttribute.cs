using System.ComponentModel.DataAnnotations;
using PerfectMedia.UI.Resources;

namespace PerfectMedia.UI.Validations
{
    public class PositiveAttribute : RangeAttribute
    {
        public PositiveAttribute()
            : base(0, int.MaxValue)
        {
            ErrorMessageResourceType = typeof(Validation);
            ErrorMessageResourceName = "MustBePositive";
        }
    }
}
