using Newtonsoft.Json;

namespace PandaSharp.Services.Plan.Response
{
    public sealed class BranchResponse
    {
        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("shortKey")]
        public string ShortKey { get; set; }

        [JsonProperty("name")]
        public string LongName { get; set; }

        [JsonProperty("key")]
        public string LongKey { get; set; }

        [JsonProperty("enabled")]
        public bool IsEnabled { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}