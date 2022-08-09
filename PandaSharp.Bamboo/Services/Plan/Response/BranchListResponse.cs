using Newtonsoft.Json;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Services.Converter;
using PandaSharp.Framework.Services.Response;

namespace PandaSharp.Bamboo.Services.Plan.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<BranchListResponse, BranchResponse>))]
    [JsonRootElementPath("branches")]
    [JsonListContentPath("branches.branch.[*]")]
    public sealed class BranchListResponse : ListResponseBase<BranchResponse>
    {
    }
}