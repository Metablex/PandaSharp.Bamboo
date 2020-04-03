using Newtonsoft.Json;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<VcsBranchListResponse, VcsBranchResponse>))]
    [JsonRootElementPath("branches")]
    [JsonListContentPath("branches.branch.[*]")]
    public sealed class VcsBranchListResponse : ListResponseBase<VcsBranchResponse>
    {
    }
}