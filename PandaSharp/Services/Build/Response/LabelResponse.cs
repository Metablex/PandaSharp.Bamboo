using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class LabelResponse
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }
    }
}