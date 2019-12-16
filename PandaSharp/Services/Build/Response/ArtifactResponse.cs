using Newtonsoft.Json;
using PandaSharp.Services.Common.Response;

namespace PandaSharp.Services.Build.Response
{
    public sealed class ArtifactResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shared")]
        public bool IsShared { get; set; }

        [JsonProperty("link")]
        public LinkResponse LinkedResource { get; set; }
    }
}