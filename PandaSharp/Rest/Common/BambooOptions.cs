using PandaSharp.Rest.Contract;

namespace PandaSharp.Rest.Common
{
    internal sealed class BambooOptions : IBambooOptions
    {
        private const string RestApiResource = "/rest/api/latest";

        private string _baseUrl;

        public string BaseUrl
        {
            get => _baseUrl;
            set
            {
                _baseUrl = value;
                if (!_baseUrl.EndsWith(RestApiResource))
                {
                    _baseUrl += RestApiResource;
                }
            }
        }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
