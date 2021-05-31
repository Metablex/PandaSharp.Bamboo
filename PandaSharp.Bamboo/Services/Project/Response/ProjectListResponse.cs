using Newtonsoft.Json;
using PandaSharp.Bamboo.Services.Common.Response;
using PandaSharp.Bamboo.Services.Common.Response.Converter;
using PandaSharp.Framework.Attributes;

namespace PandaSharp.Bamboo.Services.Project.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<ProjectListResponse, ProjectResponse>))]
    [JsonRootElementPath("projects")]
    [JsonListContentPath("projects.project.[*]")]
    public sealed class ProjectListResponse : ListResponseBase<ProjectResponse>
    {
    }
}
