using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI
{
    public class PositiveAttribute : RangeAttribute
    {
        public PositiveAttribute()
            : base(0, int.MaxValue)
        { }

        public override bool IsValid(object value)
        {
            //if (value != null)
            {
                return base.IsValid(value);
            }
            //return true;
        }
    }
}
