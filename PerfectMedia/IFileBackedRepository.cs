using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia
{
    public interface IFileBackedRepository
    {
        IDictionary<string, string> Load();
        void Save(IDictionary<string, string> data);
    }
}
