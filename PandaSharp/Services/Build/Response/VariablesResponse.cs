using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class VariablesResponse : ListResponseBase
    {
        [DeserializeAs(Name = "variable")]
        public List<VariableResponse> Contents { get; set; }
    }
}