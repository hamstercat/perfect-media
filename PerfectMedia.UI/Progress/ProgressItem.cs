using System;
using System.Threading.Tasks;
using Anotar.Log4Net;
using PerfectMedia.Serialization;
using PerfectMedia.TvShows;
using PerfectMedia.Movies;
using PerfectMedia.UI.Movies;
using PerfectMedia.UI.TvShows;

namespace PerfectMedia.UI.Progress
{
    public class ProgressItem
    {
        private readonly Lazy<string> _display;
        private readonly Func<Task> _action;

        public string Display
        {
            get { return _display.Value; }
        }

        public string Message
        {
            get
            {
                if (string.IsNullOrEmpty(Error))
                {
                    if (!string.IsNullOrEmpty(Warning))
                    {
                        return string.Format("{0}{1}{2}", General.Warning, General.Semicolon, Warning);
                    }
                    return string.Empty;
                }
                return Error;
            }
        }

        public string UniqueKey { get; private set; }
        public string Error { get; private set; }
        public string Warning { get; private set; }

        public ProgressItem(string uniqueKey, Lazy<string> display, Func<Task> action)
        {
            UniqueKey = uniqueKey;
            _display = display;
            _action = action;
        }

        public async Task Execute()
        {
            bool retry = await TryExecute();
            if (retry)
            {
                await TryExecute();
            }
        }

        private async Task<bool> TryExecute()
        {
            try
            {
                await _action();
            }
            catch (EpisodeNotFoundException)
            {
                Error = TvShowResources.EpisodeNotFound;
            }
            catch (TvShowNotFoundException)
            {
                Error = TvShowResources.TvShowNotFound;
            }
            catch (MovieNotFoundException)
            {
                Error = MovieResources.MovieNotFound;
            }
            catch (InvalidNfoException)
            {
                Warning = General.InvalidNfo;
                return true;
            }
            catch (Exception ex)
            {
                Error = General.UnhandledExceptionOnUpdate;
                LogTo.ErrorException(Display, ex);
            }
            return false;
        }
    }
}
