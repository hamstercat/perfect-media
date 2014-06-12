using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.Sources
{
    internal class XmlFile
    {
        public string Path { get; private set; }
        
        public bool Exists
        {
            get
            {
                return File.Exists(Path);
            }
        }

        public XmlFile(string path)
        {
            Path = path;
        }
    }
}
