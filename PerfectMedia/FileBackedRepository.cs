using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PerfectMedia
{
    public class FileBackedRepository : IFileBackedRepository
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly string _repositoryFile;

        public FileBackedRepository(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
            // Save the file in an XML located in the same folder as the executable
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string assemblyFolder = Path.GetDirectoryName(assemblyLocation);
            _repositoryFile = Path.Combine(assemblyFolder, "Cache.xml");
        }

        public IDictionary<string, string> Load()
        {
            if (_fileSystemService.FileExists(_repositoryFile))
            {
                XElement root = XElement.Load(_repositoryFile);
                return root.Elements().ToDictionary(pair => pair.Attribute("key").Value, val => val.Value);
            }
            return new Dictionary<string, string>();
        }

        public void Save(IDictionary<string, string> data)
        {
            XElement root = new XElement("root",
                data.Select(pair => new XElement("pair",
                    new XAttribute("key", pair.Key),
                    pair.Value)));
            root.Save(_repositoryFile);
        }
    }
}
