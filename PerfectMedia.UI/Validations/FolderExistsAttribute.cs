using System.ComponentModel.DataAnnotations;
using System.IO;

namespace PerfectMedia.UI.Validations
{
    public class FolderExistsAttribute : ValidationAttribute
    {
        public FolderExistsAttribute()
        {
            ErrorMessageResourceType = typeof(ValidationsResources);
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
