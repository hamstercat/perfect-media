using Ninject;
using PerfectMedia.FileInformation;
using PerfectMedia.Sources;
using PerfectMedia.TvShows;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Properties;
using PerfectMedia.UI.ViewModels.TvShows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ServiceLocator()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<ISourceRepository>().To<SourceRepository>();
            _kernel.Bind<ISourceService>().To<SourceService>();
            _kernel.Bind<IFileSystemService>().To<FileSystemService>();
            _kernel.Bind<IFileInformationService>().To<FileInformationService>();
            BindTvShowDependencies();
        }

        private void BindTvShowDependencies()
        {
            string theTvDbBaseUrl = ConfigurationManager.AppSettings["TheTvDbUrl"];
            IRestApiService thetvdbRestApi = new RestApiService(theTvDbBaseUrl);

            //_kernel.Bind<TvShowManagerViewModel>().ToSelf();
            _kernel.Bind<ITvShowViewModelFactory>().To<TvShowViewModelFactory>();
            _kernel.Bind<ITvShowFileService>().To<TvShowFileService>();
            _kernel.Bind<ITvShowMetadataService>().To<TvShowMetadataService>();
            _kernel.Bind<ITvShowMetadataRepository>().To<TvShowMetadataRepository>();
            _kernel.Bind<IEpisodeMetadataRepository>().To<EpisodeMetadataRepository>();
            _kernel.Bind<ITvShowImagesService>().To<TvShowImagesService>();
            _kernel.Bind<ITvShowMetadataUpdater>().To<ThetvdbTvShowMetadataUpdater>()
                .WithConstructorArgument<IRestApiService>(thetvdbRestApi);
            _kernel.Bind<IEpisodeMetadataService>().To<EpisodeMetadataService>();
        }
    }
}
