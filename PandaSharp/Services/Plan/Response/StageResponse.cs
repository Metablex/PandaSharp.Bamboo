using RestSharp.Deserializers;

namespace PandaSharp.Services.Plan.Response
{
    public sealed class StageResponse
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "manual")]
        public bool IsManual { get; set; }
    }
}