using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class ChangeResponse
    {
        [DeserializeAs(Name = "author")]
        public string Author { get; set; }

        [DeserializeAs(Name = "userName")]
        public string UserName { get; set; }

        [DeserializeAs(Name = "fullName")]
        public string FullName { get; set; }

        [DeserializeAs(Name = "changesetId")]
        public string ChangeSetId { get; set; }
    }
}