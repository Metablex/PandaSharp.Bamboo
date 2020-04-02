using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Request.Base;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Types;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Build.Request
{
    internal sealed class DeleteLabelOfBuildCommand : BuildCommandBase, IDeleteLabelOfBuildCommand
    {
        [InjectedProperty(RequestPropertyNames.LabelName)]
        public string Label { get; set; }

        public DeleteLabelOfBuildCommand(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        protected override string GetResourcePath()
        {
            return $"result/{ProjectKey}-{PlanKey}-{BuildNumber}/label/{Label}";
        }

        protected override Method GetRequestMethod()
        {
            return Method.DELETE;
        }
    }
}