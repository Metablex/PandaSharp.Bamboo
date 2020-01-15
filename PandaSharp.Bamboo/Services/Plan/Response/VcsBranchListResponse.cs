using Newtonsoft.Json;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<VcsBranchListResponse, VcsBranchResponse>))]
    [JsonItems("branch")]
    [JsonRootElement("branches")]
    public sealed class VcsBranchListResponse : ListResponseBase<VcsBranchResponse>
    {

    }
}