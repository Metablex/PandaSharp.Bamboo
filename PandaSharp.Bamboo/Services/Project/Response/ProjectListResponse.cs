using Newtonsoft.Json;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Services.Converter;
using PandaSharp.Framework.Services.Response;

namespace PandaSharp.Bamboo.Services.Project.Response
{
    [JsonConverter(typeof(RootElementResponseConverter<ProjectListResponse, ProjectResponse>))]
    [JsonRootElementPath("projects")]
    [JsonListContentPath("projects.project.[*]")]
    public sealed class ProjectListResponse : ListResponseBase<ProjectResponse>
    {
    }
}
