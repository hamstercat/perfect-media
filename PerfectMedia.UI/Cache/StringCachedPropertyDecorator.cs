using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Cache
{
    public class StringCachedPropertyDecorator : CachedPropertyDecorator<string>
    {
        public StringCachedPropertyDecorator(IKeyDataStore keyDataStore, string propertyKey)
            : base(keyDataStore, propertyKey)
        { }

        protected override string ConvertToString(string item)
        {
            return item;
        }

        protected override string ConvertFromString(string str)
        {
            return str;
        }
    }
}
