using PandaSharp.Services.Common;
using System;

namespace PandaSharp.Utils
{
    public static class RequestBaseExtensions
    {
        public static TResponse Execute<TResponse>(this IRequestBuilderBase<TResponse> requestBuilder)
            where TResponse : class, new()
        {
            if (!(requestBuilder is IRestClientProvider restClientProvider))
            {
                throw new ArgumentException("Request does not support sending REST requests.");
            }

            var client = restClientProvider.ProvideClient();
            var request = requestBuilder.Build();
            var response = client.Execute<TResponse>(request);

            return response.Data;
        }
    }
}
