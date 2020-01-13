using Newtonsoft.Json;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    public sealed class ActionResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}