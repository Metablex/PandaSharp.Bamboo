using RestSharp.Deserializers;

namespace PandaSharp.Services.Common.Response
{
    public abstract class ListResponseBase
    {
        [DeserializeAs(Name = "size")]
        public int Size { get; set; }

        [DeserializeAs(Name = "start-index")]
        public int StartIndex { get; set; }

        [DeserializeAs(Name = "max-result")]
        public int MaxResult { get; set; }
    }
}