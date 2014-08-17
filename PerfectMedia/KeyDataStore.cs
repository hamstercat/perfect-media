using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectMedia
{
    public class KeyDataStore : IKeyDataStore, ILifecycleService
    {
        private readonly IFileBackedRepository _fileBackedRepository;
        private IDictionary<string, string> _dataStore;

        public KeyDataStore(IFileBackedRepository fileBackedRepository)
        {
            _fileBackedRepository = fileBackedRepository;
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

        void ILifecycleService.Initialize()
        {
            _dataStore = _fileBackedRepository.Load();
        }

        void ILifecycleService.Uninitialize()
        {
            if (_dataStore != null && _dataStore.Any())
            {
                _fileBackedRepository.Save(_dataStore);
            }
        }
    }
}
