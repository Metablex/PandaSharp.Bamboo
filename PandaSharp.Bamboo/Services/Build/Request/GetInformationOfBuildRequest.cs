using System;
using PandaSharp.Bamboo.Services.Build.Aspect;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Expansion;
using PandaSharp.Bamboo.Services.Build.Request.Base;
using PandaSharp.Bamboo.Services.Build.Response;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Request
{
    [SupportsParameterAspect(typeof(IGetInformationOfBuildParameterAspect))]
    internal sealed class GetInformationOfBuildRequest : BuildRequestBase<BuildResponse>, IGetInformationOfBuildRequest
    {
        public GetInformationOfBuildRequest(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory, IRestResponseConverter restResponseConverter)
            : base(restClientFactory, parameterAspectFactory, restResponseConverter)
        {
        }

        public IGetInformationOfBuildRequest IncludeBuildInformation(params Action<IBuildInformationExpansion>[] expansions)
        {
            GetAspect<IGetInformationOfBuildParameterAspect>().IncludeBuildInformation(expansions);
            return this;
        }

        protected override string GetResourcePath()
        {
            return $"result/{ProjectKey}-{PlanKey}-{BuildNumber}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.GET;
        }
    }
}