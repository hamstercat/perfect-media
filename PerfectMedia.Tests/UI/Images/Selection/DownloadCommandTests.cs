using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace PerfectMedia.UI.Images.Selection
{
    public class DownloadCommandTests
    {
        private readonly DownloadCommand _command;
        private readonly IChooseImageFileViewModel _chooseImageViewModel;

        public DownloadCommandTests()
        {
            _chooseImageViewModel = Substitute.For<IChooseImageFileViewModel>();
            _command = new DownloadCommand(_chooseImageViewModel);
        }
    }
}
