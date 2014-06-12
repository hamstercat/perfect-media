using Ninject;
using PerfectMedia.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI
{
    // TODO: find out how to not use a service locator for the ViewModels like in a ASP.NET MVC project
    internal static class ServiceLocator
    {
        private static readonly IKernel _kernel;

        static ServiceLocator()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<ISourceRepository>().To<SourceRepository>();
        }

        internal static TService Get<TService>()
        {
            return _kernel.Get<TService>();
        }
    }
}
