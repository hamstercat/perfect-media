using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia
{
    public interface IRestApiService
    {
        string Get(string url);
        T Get<T>(string url) where T : new();
    }
}
