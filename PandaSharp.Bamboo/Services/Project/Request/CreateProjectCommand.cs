using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Project.Aspect;
using PandaSharp.Bamboo.Services.Project.Contract;
using PandaSharp.Framework.Attributes;
using PandaSharp.Framework.Rest.Contract;
using PandaSharp.Framework.Services.Aspect;
using PandaSharp.Framework.Services.Request;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Project.Request
{
    [SupportsParameterAspect(typeof(ICreateProjectCommandAspect))]
    internal sealed class CreateProjectCommand : CommandBase, ICreateProjectCommand
    {
        [InjectedProperty(RequestPropertyNames.ProjectKey)]
        public string ProjectKey
        {
            set => GetAspect<ICreateProjectCommandAspect>().SetProjectKey(value);
        }

        [InjectedProperty(RequestPropertyNames.ProjectName)]
        public string ProjectName
        {
            set => GetAspect<ICreateProjectCommandAspect>().SetProjectName(value);
        }

        public CreateProjectCommand(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public ICreateProjectCommand WithDescription(string description)
        {
            GetAspect<ICreateProjectCommandAspect>().SetDescription(description);
            return this;
        }

        public ICreateProjectCommand EnablePublicAccess()
        {
            GetAspect<ICreateProjectCommandAspect>().EnablePublicAccess(true);
            return this;
        }

        protected override string GetResourcePath()
        {
            return "project";
        }

        protected override Method GetRequestMethod()
        {
            return Method.POST;
        }
    }
}