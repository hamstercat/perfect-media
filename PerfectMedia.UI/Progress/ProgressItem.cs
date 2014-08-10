using System;
using System.Threading.Tasks;
using PerfectMedia.TvShows;
using PerfectMedia.Movies;

namespace PerfectMedia.UI.Progress
{
    public class ProgressItem
    {
        private readonly Lazy<string> _display;
        private readonly Func<Task> _action;

        public string Display
        {
            get
            {
                return _display.Value;
            }
        }
        public string Error { get; private set; }

        public ProgressItem(Lazy<string> display, Func<Task> action)
        {
            _display = display;
            _action = action;
        }

        public async Task Execute()
        {
            try
            {
                await _action();
            }
            catch (EpisodeNotFoundException)
            {
                Error = "Episode could not be located";
            }
            catch (TvShowNotFoundException)
            {
                Error = "TV Show could not be located";
            }
            catch(MovieNotFoundException)
            {
                Error = "Movie could not be located";
            }
            catch (Exception)
            {
                Error = "Unhandled exception (check the log for more information)";
            }
        }
    }
}
