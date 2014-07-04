﻿using Ninject;
using Ninject.Extensions.Conventions;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.TvShows;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace PerfectMedia.UI
{
    public class ServiceLocator
    {
        private readonly IKernel _kernel;

        public TvShowManagerViewModel TvShowManagerViewModel
        {
            get
            {
                return _kernel.Get<TvShowManagerViewModel>();
            }
        }

        private IRestApiService TheTvDbRestApi
        {
            get
            {
                string theTvDbBaseUrl = ConfigurationManager.AppSettings["TheTvDbUrl"];
                return new RestApiService(theTvDbBaseUrl);
            }
        }

        public ServiceLocator()
        {
            _kernel = new StandardKernel();
            BindDependencies();
        }

        private void BindDependencies()
        {
            string currentAssemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _kernel.Bind(config => config
                .FromAssembliesInPath(currentAssemblyLocation, assembly =>
                {
                    // Only load assemblies from PerfectMedia, and don't include PerfectMedia.UI.vshost.exe generated by Visual Studio when debugging
                    string assemblyName = assembly.ManifestModule.Name;
                    return assemblyName.StartsWith("PerfectMedia") && !assemblyName.EndsWith("vshost.exe");
                })
                .SelectAllClasses()
                .BindAllInterfaces()
                .ConfigureFor<ThetvdbTvShowMetadataUpdater>(tvShowMetadataUpdater => tvShowMetadataUpdater.WithConstructorArgument(TheTvDbRestApi)));
        }
    }
}
