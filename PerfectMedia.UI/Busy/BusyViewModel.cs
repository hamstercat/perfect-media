using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace PerfectMedia.UI.Busy
{
    [ImplementPropertyChanged]
    public class BusyViewModel : IBusyProvider
    {
        private int Counter { get; set; }

        public bool IsBusy
        {
            get { return Counter != 0; }
        }

        public IDisposable DoWork()
        {
            Counter++;
            return new BusyViewModelDisposable(this);
        }

        private class BusyViewModelDisposable : IDisposable
        {
            private readonly BusyViewModel _viewModel;
            private bool _disposed;

            public BusyViewModelDisposable(BusyViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public void Dispose()
            {
                if(_disposed) throw new InvalidOperationException("Object was already disposed");

                _disposed = true;
                _viewModel.Counter--;
            }
        }
    }
}
