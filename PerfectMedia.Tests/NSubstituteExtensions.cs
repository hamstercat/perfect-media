using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia
{
    public static class NSubstituteExtensions
    {
        public static void Async(this Task task)
        {
            // Do nothing, this method only exists to remove the following warning in the tests:
            // "Because this call is not awaited, execution of the current method continues before the call is completed.
            // Consider applying the 'await' operator to the result of the call."
        }

        public static Task<T> ToTask<T>(this T @this)
        {
            return Task.FromResult(@this);
        }
    }
}
