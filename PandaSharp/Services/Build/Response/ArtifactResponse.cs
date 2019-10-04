using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class ArtifactResponse
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "shared")]
        public bool IsShared { get; set; }

        [DeserializeAs(Name = "link")]
        public LinkResponse LinkedResource { get; set; }
    }
}