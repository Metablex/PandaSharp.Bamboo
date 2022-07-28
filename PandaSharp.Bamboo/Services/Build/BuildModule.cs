using PandaSharp.Bamboo.Services.Build.Aspect;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Factory;
using PandaSharp.Bamboo.Services.Build.Request;
using PandaSharp.Framework.IoC.Contract;

namespace PandaSharp.Bamboo.Services.Build
{
    internal sealed class BuildModule : IPandaContainerModule
    {
        public void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<IGetBuildsOfPlanRequest, GetBuildsOfPlanRequest>();
            container.RegisterType<IGetInformationOfBuildRequest, GetInformationOfBuildRequest>();
            container.RegisterType<IGetCommentsOfBuildRequest, GetCommentsOfBuildRequest>();
            container.RegisterType<IAddCommentToBuildCommand, AddCommentToBuildCommand>();
            container.RegisterType<IGetLabelsOfBuildRequest, GetLabelsOfBuildRequest>();
            container.RegisterType<IAddLabelToBuildCommand, AddLabelToBuildCommand>();
            container.RegisterType<IDeleteLabelOfBuildCommand, DeleteLabelOfBuildCommand>();
            container.RegisterType<IBuildStateParameterAspect, BuildStateParameterAspect>();
            container.RegisterType<ILabelFilterParameterAspect, LabelFilterParameterAspect>();
            container.RegisterType<IIssueFilterParameterAspect, IssueFilterParameterAspect>();
            container.RegisterType<IGetBuildsOfPlanParameterAspect, GetBuildsOfPlanParameterAspect>();
            container.RegisterType<IGetInformationOfBuildParameterAspect, GetInformationOfBuildParameterAspect>();
            container.RegisterType<IBuildRequestBuilderFactory, BuildRequestBuilderFactory>();
        }
    }
}