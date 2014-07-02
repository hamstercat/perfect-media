using PerfectMedia.FileInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.Progress
{
    public class ProgressItem
    {
        private readonly Action _action;

        public string Display { get; private set; }
        public string Error { get; private set; }

        public ProgressItem(string display, Action action)
        {
            Display = display;
            _action = action;
        }

        public void Execute()
        {
            try
            {
                _action();
            }
            catch (UnknownCodecException ex)
            {
                // TODO: show something else than the error message
                Error = ex.Message;
            }
            catch (ItemNotFoundException ex)
            {
                Error = "No metadata could be found";
            }
            catch (Exception ex)
            {
                Error = "Unhandled exception";
            }
        }
    }
}
