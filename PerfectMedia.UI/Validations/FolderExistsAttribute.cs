using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectMedia.UI.Properties;

namespace PerfectMedia.UI.Validations
{
    public class FolderExistsAttribute : ValidationAttribute
    {
        public FolderExistsAttribute()
        {
            ErrorMessageResourceType = typeof(Resources);
            ErrorMessageResourceName = "FolderDoesntExist";
        }

        public override bool IsValid(object value)
        {
            var folder = (string)value;
            if (!string.IsNullOrEmpty(folder))
            {
                return Directory.Exists(folder);
            }
            return true;
        }
    }
}
