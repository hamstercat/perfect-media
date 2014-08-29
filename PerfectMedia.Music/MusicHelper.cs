using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Music
{
    internal static class MusicHelper
    {
        internal static string FindArtistNameFromFolder(string path)
        {
            return Path.GetFileName(path);
        }
    }
}
