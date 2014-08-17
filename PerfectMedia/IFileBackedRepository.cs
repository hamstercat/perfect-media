using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectMedia
{
    public interface IFileBackedRepository
    {
        IDictionary<string, string> Load();
        void Save(IDictionary<string, string> data);
    }
}
