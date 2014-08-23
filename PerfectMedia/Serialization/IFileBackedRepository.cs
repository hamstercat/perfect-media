using System.Collections.Generic;

namespace PerfectMedia.Serialization
{
    public interface IFileBackedRepository
    {
        IDictionary<string, string> Load();
        void Save(IDictionary<string, string> data);
    }
}
