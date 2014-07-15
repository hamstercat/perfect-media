﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Movies
{
    internal static class MovieHelper
    {
        internal static string ThemoviedbApiKey
        {
            get
            {
                return ConfigurationManager.AppSettings["ThemoviedbApiKey"];
            }
        }

        internal static string ThemoviedbUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["ThemoviedbUrl"];
            }
        }

        internal static string ExpandImageurl(string relativePath)
        {
            return string.Format("{0}/{1}", ThemoviedbUrl.TrimEnd('/'), relativePath.TrimStart('/'));
        }
    }
}