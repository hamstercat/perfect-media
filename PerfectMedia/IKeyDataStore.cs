
namespace PerfectMedia
{
    public interface IKeyDataStore
    {
        string GetValue(string key);
        void SetValue(string key, string value);
    }
}
