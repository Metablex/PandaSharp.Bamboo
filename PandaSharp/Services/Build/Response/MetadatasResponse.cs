using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class MetadatasResponse : ListResponseBase<MetadataResponse>
    {
        [DeserializeAs(Name = "item")]
        public override List<MetadataResponse> InnerList { get; set; }
    }
}