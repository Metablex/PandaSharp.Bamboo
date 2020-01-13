using Newtonsoft.Json;

namespace PandaSharp.Bamboo.Services.Users.Response
{
    public sealed class CurrentUserResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}