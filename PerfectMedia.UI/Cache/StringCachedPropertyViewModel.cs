﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Cache
{
    public class StringCachedPropertyViewModel : CachedPropertyViewModel<string>
    {
        public StringCachedPropertyViewModel(IKeyDataStore keyDataStore, string propertyKey, bool isRequired)
            : base(keyDataStore, propertyKey, isRequired)
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
