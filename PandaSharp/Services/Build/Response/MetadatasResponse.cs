using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class MetadatasResponse : ListResponseBase
    {
        [DeserializeAs(Name = "item")]
        public List<MetadataResponse> Contents { get; set; }
    }
}