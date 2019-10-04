using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class VariablesResponse : ListResponseBase<VariableResponse>
    {
        [DeserializeAs(Name = "variable")]
        public override List<VariableResponse> InnerList { get; set; }
    }
}