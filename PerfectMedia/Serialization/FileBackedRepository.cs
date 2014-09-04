using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace PerfectMedia.Serialization
{
    public class FileBackedRepository : IFileBackedRepository
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly string _repositoryFile;

        public FileBackedRepository(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
            _repositoryFile = SettingsHelper.GetAppDataFilePath("Cache.xml");
        }

        public IDictionary<string, string> Load()
        {
            if (_fileSystemService.FileExistsSynchronously(_repositoryFile))
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
