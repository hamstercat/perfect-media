using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectMedia.UI.Properties;

namespace PerfectMedia.UI.Validation
{
    public class LocalizedRequiredAttribute : RequiredAttribute
    {
        public LocalizedRequiredAttribute()
        {
            ErrorMessageResourceType = typeof(Resources);
            ErrorMessageResourceName = "RequiredField";
        }
    }
}
