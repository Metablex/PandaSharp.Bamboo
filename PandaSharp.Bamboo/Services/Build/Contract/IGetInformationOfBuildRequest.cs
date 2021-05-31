using System;
using PandaSharp.Bamboo.Services.Build.Expansion;
using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Framework.Services.Contract;

namespace PandaSharp.Bamboo.Services.Build.Contract
{
    public interface IGetInformationOfBuildRequest : IRequestBase<BuildResponse>
    {
        IGetInformationOfBuildRequest IncludeBuildInformation(params Action<IBuildInformationExpansion>[] expansions);
    }
}