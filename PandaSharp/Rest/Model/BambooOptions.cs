using PandaSharp.Rest.Contract;

namespace PandaSharp.Rest.Model
{
    internal class BambooOptions : IBambooOptions
    {
        public string BaseUrl { get; }

        public string UserName { get; }

        public string Password { get; }

        public BambooOptions(string baseUrl, string userName, string password)
        {
            BaseUrl = baseUrl;
            UserName = userName;
            Password = password;
        }
    }
}
