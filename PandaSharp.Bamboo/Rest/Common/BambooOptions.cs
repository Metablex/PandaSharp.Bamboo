using PandaSharp.Bamboo.Rest.Contract;

namespace PandaSharp.Bamboo.Rest.Common
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
        
        public IBambooAuthentication Authentication { get; } = new BambooAuthentication();
    }
}
