using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectMedia
{
    public interface IFileBackedRepository
    {
        Task<IDictionary<string, string>> Load();
        void Save(IDictionary<string, string> data);
    }
}
