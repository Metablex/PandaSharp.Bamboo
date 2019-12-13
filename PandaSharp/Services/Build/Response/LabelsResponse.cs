using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class LabelsResponse : ListResponseBase
    {
        [DeserializeAs(Name = "label")]
        public List<LabelResponse> Contents { get; set; }
    }
}