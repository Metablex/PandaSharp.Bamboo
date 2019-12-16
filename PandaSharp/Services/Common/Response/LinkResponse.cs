using Newtonsoft.Json;

namespace PandaSharp.Services.Common.Response
{
    public sealed class LinkResponse
    {
        [JsonProperty("href")]
        public string Location { get; set; }

        [JsonProperty("rel")]
        public string Relation { get; set; }
    }
}