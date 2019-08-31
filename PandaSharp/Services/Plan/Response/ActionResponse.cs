using RestSharp.Deserializers;

namespace PandaSharp.Services.Plan.Response
{
    public sealed class ActionResponse
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }
    }
}