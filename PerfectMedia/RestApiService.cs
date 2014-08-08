using System.Net;
using Anotar.Log4Net;
using RestSharp;

namespace PerfectMedia
{
    public class RestApiService : IRestApiService
    {
        private readonly IRestClient _restClient;
        private readonly string _dateFormat;

        public RestApiService(string baseUrl, string dateFormat)
        {
            _restClient = new RestClient(baseUrl);
            _dateFormat = dateFormat;
        }

        public string Get(string url)
        {
            IRestResponse response = ExecuteRequest(url);
            ValidateStatusCode(response, url);
            return response.Content;
        }

        public T Get<T>(string url)
            where T : new()
        {
            IRestResponse<T> response = ExecuteRequest<T>(url);
            ValidateStatusCode(response, url);
            return response.Data;
        }

        private IRestResponse ExecuteRequest(string url)
        {
            RestRequest request = new RestRequest(url);
            request.DateFormat = _dateFormat;
            return _restClient.Execute(request);
        }

        private IRestResponse<T> ExecuteRequest<T>(string url)
            where T : new()
        {
            RestRequest request = new RestRequest(url);
            request.DateFormat = _dateFormat;
            return _restClient.Execute<T>(request);
        }

        private void ValidateStatusCode(IRestResponse response, string url)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                string message = string.Format("Response code {0}: {1}", (int)response.StatusCode, response.ErrorMessage);
                LogTo.Warn("API with base \"{0}\" on URL \"{1}\":", _restClient.BaseUrl, url);
                LogTo.Warn("    {0}", message);
                throw new ApiException(message);
            }
        }
    }
}
