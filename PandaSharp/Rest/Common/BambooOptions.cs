using PandaSharp.Rest.Contract;

namespace PandaSharp.Rest.Common
{
    internal sealed class BambooOptions : IBambooOptions
    {
        private const string RestApiResource = "/rest/api/latest";

        public string BaseUrl { get; }

        public string UserName { get; }

        public string Password { get; }

        public BambooOptions(string baseUrl, string userName, string password)
        {
            BaseUrl = baseUrl;
            if (!BaseUrl.EndsWith(RestApiResource))
            {
                BaseUrl += RestApiResource;
            }

            UserName = userName;
            Password = password;
        }
    }
}
