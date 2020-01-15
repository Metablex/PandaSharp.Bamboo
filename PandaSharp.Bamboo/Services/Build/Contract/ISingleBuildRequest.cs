using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Services.Common.Contract;

namespace PandaSharp.Bamboo.Services.Build.Contract
{
    public interface ISingleBuildRequest : IRequestBase<BuildResponse>
    {
        ISingleBuildRequest IncludingArtifacts();

        ISingleBuildRequest IncludingComments();

        ISingleBuildRequest IncludingLabels();

        ISingleBuildRequest IncludingJiraIssues();

        ISingleBuildRequest IncludingVariables();

        ISingleBuildRequest IncludingStages();

        ISingleBuildRequest IncludingChanges();

        ISingleBuildRequest IncludingMetaData();
    }
}