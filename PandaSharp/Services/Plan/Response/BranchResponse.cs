using RestSharp.Deserializers;

namespace PandaSharp.Services.Plan.Response
{
    public sealed class BranchResponse
    {
        [DeserializeAs(Name = "shortName")]
        public string ShortName { get; set; }

        [DeserializeAs(Name = "shortKey")]
        public string ShortKey { get; set; }

        [DeserializeAs(Name = "name")]
        public string LongName { get; set; }

        [DeserializeAs(Name = "key")]
        public string LongKey { get; set; }

        [DeserializeAs(Name = "enabled")]
        public bool IsEnabled { get; set; }

        [DeserializeAs(Name = "description")]
        public string Description { get; set; }
    }
}