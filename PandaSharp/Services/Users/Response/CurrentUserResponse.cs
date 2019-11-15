using RestSharp.Deserializers;

namespace PandaSharp.Services.Users.Response
{
    public sealed class CurrentUserResponse
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "fullName")]
        public string FullName { get; set; }

        [DeserializeAs(Name = "email")]
        public string Email { get; set; }
    }
}