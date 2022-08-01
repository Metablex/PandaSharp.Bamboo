using PandaSharp.Framework.Rest.Contract;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Common.Rest
{
    internal sealed class RestResponseConverter : IRestResponseConverter
    {
        public T ConvertRestResponse<T>(IRestResponse<T> response)
        {
            return response.Data;
        }
    }
}