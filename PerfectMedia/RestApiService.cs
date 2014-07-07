using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia
{
    public class RestApiService : IRestApiService
    {
        private readonly IRestClient _restClient;

        public RestApiService(string baseUrl, string dateFormat)
        {
            _restClient = new RestClient(baseUrl);
            _dateFormat = dateFormat;
        }

        public T Get<T>(string url)
            where T : new()
        {
            IRestResponse<T> response = ExecuteRequest<T>(url);
            ValidateStatusCode(response);
            return response.Data;
        }

        private IRestResponse<T> ExecuteRequest<T>(string url)
        {
            RestRequest request = new RestRequest(url);
            request.DateFormat = _dateFormat;
            return _restClient.Execute<T>(request);
        }

        private void ValidateStatusCode(IRestResponse response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                string message = string.Format("Response code {0}: {1}", (int)response.StatusCode, response.ErrorMessage);
                throw new ScrapperException(message);
            }
        }
    }
}
