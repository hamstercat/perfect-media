using System.Threading.Tasks;

namespace PerfectMedia.ExternalApi
{
    public interface IRestApiService
    {
        void SetHeader(string header, string value);
        void SetRateLimiter(int maximumNumberOfCallsBySecond);
        Task<string> Get(string url);
        Task<T> Get<T>(string url) where T : new();
    }
}
