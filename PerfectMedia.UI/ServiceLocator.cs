using Ninject;
using PerfectMedia.Metadata;
using PerfectMedia.Sources;
using PerfectMedia.TvShows;
using PerfectMedia.UI.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            string theTvDbBaseUrl = ConfigurationManager.AppSettings["TheTvDbUrl"];
            IRestApiWrapper thetvdbRestApiWrapper = new RestApiWrapper(theTvDbBaseUrl);

            _kernel = new StandardKernel();
            _kernel.Bind<ISourceRepository>().To<SourceRepository>();
            _kernel.Bind<IFileSystemService>().To<FilesystemService>();
            _kernel.Bind<ITvShowService>().To<TvShowService>();
            _kernel.Bind<ITvShowLocalMetadataService>().To<TvShowLocalMetadataService>();
            _kernel.Bind<ITvShowMetadataService>().To<TvShowMetadataService>()
                .WithConstructorArgument<IRestApiWrapper>(thetvdbRestApiWrapper);
            _kernel.Bind<ISeasonMetadataService>().To<SeasonMetadataService>()
                .WithConstructorArgument<IRestApiWrapper>(thetvdbRestApiWrapper);
        }

        internal static TService Get<TService>()
        {
            return _kernel.Get<TService>();
        }
    }
}
