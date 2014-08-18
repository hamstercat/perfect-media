﻿using System;
using System.Net;
using System.Threading.Tasks;
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

        public async Task<string> Get(string url)
        {
            IRestResponse response = await ExecuteRequest(url);
            return response.Content;
        }

        public async Task<T> Get<T>(string url)
            where T : new()
        {
            IRestResponse<T> response = await ExecuteRequest<T>(url);
            return response.Data;
        }

        private Task<IRestResponse> ExecuteRequest(string url)
        {
            var request = new RestRequest(url);
            request.DateFormat = _dateFormat;
            return ExecuteAsync(request);
        }

        private Task<IRestResponse> ExecuteAsync(RestRequest request)
        {
            var taskCompletionSource = new TaskCompletionSource<IRestResponse>();
            _restClient.ExecuteAsync(request, (response) =>
            {
                if (response.ErrorException != null)
                {
                    Exception ex = TransformStatusCodeToException(response, request.Resource);
                    taskCompletionSource.TrySetException(ex);
                }
                else
                {
                    taskCompletionSource.TrySetResult(response);
                }
            });
            return taskCompletionSource.Task;
        }

        private Task<IRestResponse<T>> ExecuteRequest<T>(string url)
            where T : new()
        {
            var request = new RestRequest(url);
            request.DateFormat = _dateFormat;
            return ExecuteAsync<T>(request);
        }

        private Task<IRestResponse<T>> ExecuteAsync<T>(RestRequest request)
            where T : new()
        {
            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();
            _restClient.ExecuteAsync<T>(request, (response) =>
            {
                if (response.ErrorException != null)
                {
                    Exception ex = TransformStatusCodeToException(response, request.Resource);
                    taskCompletionSource.TrySetException(ex);
                }
                else
                {
                    taskCompletionSource.TrySetResult(response);
                }
            });
            return taskCompletionSource.Task;
        }

        private Exception TransformStatusCodeToException(IRestResponse response, string url)
        {
            string message = string.Format("Response code {0}: {1}", (int)response.StatusCode, response.ErrorMessage);
            LogTo.Warn("API with base \"{0}\" on URL \"{1}\":", _restClient.BaseUrl, url);
            LogTo.Warn("    {0}", message);
            return new ApiException(message);
        }
    }
}
