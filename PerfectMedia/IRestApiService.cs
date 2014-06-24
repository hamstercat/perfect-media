using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia
{
    public interface IRestApiService
    {
        T Get<T>(string url) where T : new();
    }
}
