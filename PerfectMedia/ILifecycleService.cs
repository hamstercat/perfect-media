using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia
{
    /// <summary>
    /// Defines that the class have initialization or destruction that should be done before the application has finished starting up.
    /// </summary>
    public interface ILifecycleService
    {
        /// <summary>
        /// Initializes this instance. Will only be called once when the application starts up.
        /// </summary>
        /// <returns></returns>
        Task Initialize();

        /// <summary>
        /// Uninitializes this instance. Will only be called once just before the application closes.
        /// </summary>
        /// <returns></returns>
        void Uninitialize();
    }
}
