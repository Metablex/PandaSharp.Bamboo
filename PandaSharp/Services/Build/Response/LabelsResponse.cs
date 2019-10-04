using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class LabelsResponse : ListResponseBase<LabelResponse>
    {
        [DeserializeAs(Name = "label")]
        public override List<LabelResponse> InnerList { get; set; }
    }
}