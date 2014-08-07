using PerfectMedia.FileInformation;
using PerfectMedia.TvShows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Error = "Episode metadata could not be found";
            }
            catch (ItemNotFoundException)
            {
                Error = "No metadata could be found";
            }
            catch (Exception)
            {
                Error = "Unhandled exception";
            }
        }
    }
}
