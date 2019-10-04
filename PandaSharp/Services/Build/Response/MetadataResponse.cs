using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class MetadataResponse
    {
        [DeserializeAs(Name = "key")]
        public string Key { get; set; }

        [DeserializeAs(Name = "value")]
        public string Value { get; set; }
    }
}