using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class ChangesResponse : ListResponseBase<ChangeResponse>
    {
        [DeserializeAs(Name = "change")]
        public override List<ChangeResponse> InnerList { get; set; }
    }
}