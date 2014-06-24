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

        public RestApiService(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
        }

        public T Get<T>(string url)
            where T : new()
        {
            RestRequest request = new RestRequest(url);
            request.DateFormat = "yyyy-MM-dd";
            IRestResponse<T> response = _restClient.Execute<T>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                string message = string.Format("Response code {0}: {1}", (int)response.StatusCode, response.ErrorMessage);
                throw new ScrapperException(message);
            }

            return response.Data;
        }
    }
}
