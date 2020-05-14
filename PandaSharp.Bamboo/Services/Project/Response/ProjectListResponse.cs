using Newtonsoft.Json;
using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Project.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<ProjectListResponse, ProjectResponse>))]
    [JsonRootElementPath("projects")]
    [JsonListContentPath("projects.project.[*]")]
    public sealed class ProjectListResponse : ListResponseBase<ProjectResponse>
    {
    }
}
