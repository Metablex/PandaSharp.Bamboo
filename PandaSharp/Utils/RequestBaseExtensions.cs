using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;

namespace PandaSharp.Utils
{
    public static class RequestBaseExtensions
    {
        public static string GetErrorResponseMessage(this IRestResponse response)
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
