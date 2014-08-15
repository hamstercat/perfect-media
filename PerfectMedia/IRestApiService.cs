using System.Threading.Tasks;

namespace PerfectMedia
{
    public interface IRestApiService
    {
        Task<string> Get(string url);
        Task<T> Get<T>(string url) where T : new();
    }
}
