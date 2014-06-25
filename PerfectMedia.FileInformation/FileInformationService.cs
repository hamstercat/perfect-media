using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.FileInformation
{
    public class FileInformationService : IFileInformationService
    {
        public VideoFileInformation GetVideoFileInformation(string file)
        {
            // TODO: implement this
            return new VideoFileInformation();
        }
    }
}
