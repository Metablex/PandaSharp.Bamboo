using System.Collections.Generic;
using PandaSharp.Services.Common.Response;
using RestSharp.Deserializers;

namespace PandaSharp.Services.Build.Response
{
    public sealed class ChangesResponse : ListResponseBase
    {
        [DeserializeAs(Name = "change")]
        public List<ChangeResponse> Contents { get; set; }
    }
}