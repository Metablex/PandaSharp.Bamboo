using PandaSharp.Bamboo.Services.Common.Contract;
using PandaSharp.Bamboo.Services.Project.Response;

namespace PandaSharp.Bamboo.Services.Project.Contract
{
    public interface IGetInformationOfRequest : IRequestBase<ProjectResponse>
    {
        IGetInformationOfRequest WithMaxResult(int maxResult);

        IGetInformationOfRequest StartAtIndex(int startIndex);

        IGetInformationOfRequest IncludePlanInformation();
    }
}