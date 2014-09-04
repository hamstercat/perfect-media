using System;
using System.Globalization;
using System.Threading;
using PerfectMedia.Properties;

namespace PerfectMedia
{
    public class GeneralSettings : IGeneralSettings, ILifecycleService
    {
        public string GetLanguage()
        {
            string language = Settings.Default.Language;
            if (string.IsNullOrEmpty(language))
            {
                return CultureInfo.CurrentCulture.Name;
            }
            return language;
        }

        public void SetLanguage(string language)
        {
            Settings.Default.Language = language;
            Settings.Default.Save();
        }

        public void Initialize()
        {
            string language = GetLanguage();
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = CultureInfo.DefaultThreadCurrentUICulture =
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(language);
        }

        public void Uninitialize()
        {
            // Do nothing
        }
    }
}