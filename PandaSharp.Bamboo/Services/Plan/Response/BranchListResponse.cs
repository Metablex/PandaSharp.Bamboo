using Newtonsoft.Json;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<BranchListResponse, BranchResponse>))]
    [JsonRootElementPath("branches")]
    [JsonListContentPath("branches.branch.[*]")]
    public sealed class BranchListResponse : ListResponseBase<BranchResponse>
    {
    }
}