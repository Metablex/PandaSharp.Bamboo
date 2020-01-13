using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Services.Common.Contract;

namespace PandaSharp.Bamboo.Services.Build.Contract
{
    public interface IBuildRequest : IRequestBase<BuildResponse>
    {
        IBuildRequest IncludingArtifacts();

        IBuildRequest IncludingComments();

        IBuildRequest IncludingLabels();

        IBuildRequest IncludingJiraIssues();

        IBuildRequest IncludingVariables();

        IBuildRequest IncludingStages();

        IBuildRequest IncludingChanges();

        IBuildRequest IncludingMetaData();
    }
}