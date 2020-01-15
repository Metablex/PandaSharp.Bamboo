using Newtonsoft.Json;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    public sealed class VcsBranchResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}