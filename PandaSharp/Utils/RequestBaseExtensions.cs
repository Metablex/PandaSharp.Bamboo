using System;
using System.Net;
using System.Text;
using PandaSharp.Services.Common.Contract;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;

namespace PandaSharp.Utils
{
    public static class RequestBaseExtensions
    {
        public static TResponse Execute<TResponse>(this IRequestBase<TResponse> requestBuilder)
            where TResponse : class, new()
        {
            if (!(requestBuilder is IRestClientProvider restClientProvider))
            {
                throw new ArgumentException("Request does not support sending REST requests.");
            }

            var client = restClientProvider.ProvideClient();
            var request = requestBuilder.Build();
            var response = client.Execute<TResponse>(request);

            if (!response.IsSuccessful)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Unable to authenticate. Please check your credentials.");
                }

                throw new InvalidOperationException($"Error retrieving response: {response.GetErrorResponseMessage()}");
            }

            return response.Data;
        }

        public static string DownloadData<TResponse>(this IRequestBase<TResponse> requestBuilder)
            where TResponse : class, new()
        {
            if (!(requestBuilder is IRestClientProvider restClientProvider))
            {
                throw new ArgumentException("Request does not support sending REST requests.");
            }

            var client = restClientProvider.ProvideClient();
            var request = requestBuilder.Build();
            var data = client.DownloadData(request);

            return data != null
                ? Encoding.UTF8.GetString(data)
                : string.Empty;
        }

        private static string GetErrorResponseMessage(this IRestResponse response)
        {
            if (response.ErrorException != null)
            {
                return response.ErrorException.ToString();
            }

            if (response.ErrorMessage != null)
            {
                return response.ErrorMessage;
            }

            var errorResponse = new JsonSerializer().Deserialize<ErrorResponse>(response);
            return errorResponse.Message;
        }

        private sealed class ErrorResponse
        {
            [DeserializeAs(Name = "message")]
            public string Message { get; set; }
        }
    }
}
