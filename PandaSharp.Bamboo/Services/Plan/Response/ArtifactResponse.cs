using Newtonsoft.Json;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    public sealed class ArtifactResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("copyPattern")]
        public string CopyPattern { get; set; }

        [JsonProperty("shared")]
        public bool IsShared { get; set; }

        [JsonProperty("required")]
        public bool IsRequired { get; set; }
    }
}