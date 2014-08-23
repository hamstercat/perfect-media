using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectMedia.UI.Properties;

namespace PerfectMedia.UI.Validation
{
    public class RatingAttribute : RangeAttribute
    {
        public RatingAttribute()
            : base(0, 10)
        {
            ErrorMessageResourceType = typeof(Resources);
            ErrorMessageResourceName = "InvalidRating";
        }
    }
}
