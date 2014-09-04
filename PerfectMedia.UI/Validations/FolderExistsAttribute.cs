using System.ComponentModel.DataAnnotations;
using System.IO;
using PerfectMedia.UI.Resources;

namespace PerfectMedia.UI.Validations
{
    public class FolderExistsAttribute : ValidationAttribute
    {
        public FolderExistsAttribute()
        {
            ErrorMessageResourceType = typeof(Validation);
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
