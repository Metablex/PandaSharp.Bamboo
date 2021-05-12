using Newtonsoft.Json;
using PandaSharp.Bamboo.Services.Common.Response;

namespace PandaSharp.Bamboo.Services.Build.Response
{
    public sealed class ArtifactResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shared")]
        public bool IsShared { get; set; }

        [JsonProperty("link")]
        public LinkResponse LinkedResource { get; set; }

        [JsonProperty("size")]
        public long FileSizeInBytes { get; set; }
    }
}