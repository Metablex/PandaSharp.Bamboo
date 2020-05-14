using PandaSharp.Bamboo.Attributes;
using PandaSharp.Bamboo.Rest.Contract;
using PandaSharp.Bamboo.Services.Common.Aspect;
using PandaSharp.Bamboo.Services.Common.Request;
using PandaSharp.Bamboo.Services.Common.Types;
using PandaSharp.Bamboo.Services.Project.Aspect;
using PandaSharp.Bamboo.Services.Project.Contract;
using RestSharp;

namespace PandaSharp.Bamboo.Services.Project.Request
{
    [SupportsParameterAspect(typeof(ICreateProjectCommandAspect))]
    internal sealed class CreateProjectCommand : CommandBase, ICreateProjectCommand
    {
        [InjectedProperty(RequestPropertyNames.ProjectKey)]
        public string ProjectKey
        {
            set => GetAspect<ICreateProjectCommandAspect>().ProjectKey = value;
        }

        [InjectedProperty(RequestPropertyNames.ProjectName)]
        public string ProjectName
        {
            set => GetAspect<ICreateProjectCommandAspect>().ProjectName = value;
        }

        public CreateProjectCommand(IRestFactory restClientFactory, IRequestParameterAspectFactory parameterAspectFactory)
            : base(restClientFactory, parameterAspectFactory)
        {
        }

        public ICreateProjectCommand WithDescription(string description)
        {
            GetAspect<ICreateProjectCommandAspect>().Description = description;
            return this;
        }

        public ICreateProjectCommand EnablePublicAccess()
        {
            GetAspect<ICreateProjectCommandAspect>().EnablePublicAccess = true;
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