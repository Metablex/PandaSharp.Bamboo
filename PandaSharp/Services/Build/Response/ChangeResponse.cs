using Newtonsoft.Json;

namespace PandaSharp.Services.Build.Response
{
    public sealed class ChangeResponse
    {
        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("changesetId")]
        public string ChangeSetId { get; set; }
    }
}