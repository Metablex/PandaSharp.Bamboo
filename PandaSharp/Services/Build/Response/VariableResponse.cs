using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class VariableResponse
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "value")]
        public string Value { get; set; }
    }
}