using System;
using System.Collections.Generic;
using System.Linq;

namespace PerfectMedia
{
    public class KeyDataStore : IKeyDataStore, IDisposable
    {
        private readonly IFileBackedRepository _fileBackedRepository;
        private readonly IDictionary<string, string> _dataStore;

        public KeyDataStore(IFileBackedRepository fileBackedRepository)
        {
            _fileBackedRepository = fileBackedRepository;
            _dataStore = _fileBackedRepository.Load();
        }

        public string GetValue(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");

            string value;
            if (_dataStore.TryGetValue(key, out value))
                return value;
            return string.Empty;
        }

        public void SetValue(string key, string value)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");

            _dataStore[key] = value;
        }

        public void Dispose()
        {
            if (_dataStore.Any())
            {
                _fileBackedRepository.Save(_dataStore);
            }
        }
    }
}
