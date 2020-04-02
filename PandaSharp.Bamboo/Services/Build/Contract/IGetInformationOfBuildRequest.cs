using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Bamboo.Services.Common.Contract;

namespace PandaSharp.Bamboo.Services.Build.Contract
{
    public interface IGetInformationOfBuildRequest : IRequestBase<BuildResponse>
    {
        IGetInformationOfBuildRequest IncludingArtifacts();

        IGetInformationOfBuildRequest IncludingComments();

        IGetInformationOfBuildRequest IncludingLabels();

        IGetInformationOfBuildRequest IncludingJiraIssues();

        IGetInformationOfBuildRequest IncludingVariables();

        IGetInformationOfBuildRequest IncludingStages();

        IGetInformationOfBuildRequest IncludingChanges();

        IGetInformationOfBuildRequest IncludingMetaData();
    }
}