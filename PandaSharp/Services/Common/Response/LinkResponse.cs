using RestSharp.Deserializers;

namespace PandaSharp.Services.Common.Response
{
    public sealed class LinkResponse
    {
        [DeserializeAs(Name = "href")]
        public string Location { get; set; }

        [DeserializeAs(Name = "rel")]
        public string Relation { get; set; }
    }
}