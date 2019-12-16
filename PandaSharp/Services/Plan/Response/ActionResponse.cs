using Newtonsoft.Json;

namespace PandaSharp.Services.Plan.Response
{
    public sealed class ActionResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}