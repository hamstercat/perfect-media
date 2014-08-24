using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Cache
{
    public class IntCachedPropertyViewModel : CachedPropertyViewModel<int?>
    {
        public IntCachedPropertyViewModel(IKeyDataStore keyDataStore, string propertyKey, bool isRequired)
            : base(keyDataStore, propertyKey, isRequired)
        { }

        protected override string ConvertToString(int? item)
        {
            if (item.HasValue)
            {
                return item.Value.ToString(CultureInfo.InvariantCulture);
            }
            return string.Empty;
        }

        protected override int? ConvertFromString(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return int.Parse(str);
            }
            return null;
        }
    }
}
