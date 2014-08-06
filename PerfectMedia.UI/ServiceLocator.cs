﻿using log4net.Config;
using Ninject;
using Ninject.Extensions.Conventions;
using PerfectMedia.Movies;
using PerfectMedia.TvShows.Metadata;
using PerfectMedia.UI.Movies;
using PerfectMedia.UI.TvShows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace PerfectMedia.UI
{
    public class ServiceLocator : IDisposable
    {
        private static readonly List<ServiceLocator> _instances = new List<ServiceLocator>();
        private readonly IKernel _kernel;

        public TvShowManagerViewModel TvShowManagerViewModel
        {
            get
            {
                return _kernel.Get<TvShowManagerViewModel>();
            }
        }

        public MovieManagerViewModel MovieManagerViewModel
        {
            get
            {
                return _kernel.Get<MovieManagerViewModel>();
            }
        }

        private IRestApiService ThetvdbRestApi
        {
            get
            {
                string theTvDbBaseUrl = ConfigurationManager.AppSettings["TheTvDbUrl"];
                return new RestApiService(theTvDbBaseUrl, "yyyy-MM-dd");
            }
        }

        private IRestApiService ThemoviedbRestApi
        {
            get
            {
                string themoviedbBaseUrl = ConfigurationManager.AppSettings["TheMovieDbUrl"];
                return new RestApiService(themoviedbBaseUrl, "yyyy-MM-dd");
            }
        }

        private IRestApiService ImdbRestApi
        {
            get
            {
                string imdbBaseUrl = ConfigurationManager.AppSettings["ImdbUrl"];
                return new RestApiService(imdbBaseUrl, "yyy-MM-dd");
            }
        }

        public ServiceLocator()
        {
            _kernel = new StandardKernel();
            XmlConfigurator.Configure();
            BindDependencies();
            _instances.Add(this);
        }

        public static void DisposeInstances()
        {
            foreach (ServiceLocator instance in _instances)
            {
                instance.Dispose();
            }
        }

        public void Dispose()
        {
            _kernel.Dispose();
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
                .ConfigureFor<ThetvdbTvShowMetadataUpdater>(tvShowMetadataUpdater => tvShowMetadataUpdater.WithConstructorArgument(ThetvdbRestApi))
                .ConfigureFor<ThemoviedbMovieMetadataUpdater>(movieMetadataUpdater => movieMetadataUpdater.WithConstructorArgument(ThemoviedbRestApi))
                .ConfigureFor<ImdbMovieSynopsisService>(movieSynopsisService => movieSynopsisService.WithConstructorArgument(ImdbRestApi))
                .ConfigureFor<KeyDataStore>(keyDataStore => keyDataStore.InSingletonScope()));
        }
    }
}
