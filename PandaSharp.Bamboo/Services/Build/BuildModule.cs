using PandaSharp.Bamboo.Services.Build.Aspect;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Factory;
using PandaSharp.Bamboo.Services.Build.Request;
using PandaSharp.Framework.IoC.Contract;
using PandaSharp.Framework.Utils;

namespace PandaSharp.Bamboo.Services.Build
{
    internal sealed class BuildModule : IPandaContextModule
    {
        public void RegisterModule(IPandaContainer container, IPandaContainerContext context)
        {
            container
                .RequestRegistrationFor<IGetBuildsOfPlanRequest>()
                .LatestRequest<GetBuildsOfPlanRequest>()
                .Register(context);

            container
                .RequestRegistrationFor<IGetInformationOfBuildRequest>()
                .LatestRequest<GetInformationOfBuildRequest>()
                .Register(context);

            container
                .RequestRegistrationFor<IGetCommentsOfBuildRequest>()
                .LatestRequest<GetCommentsOfBuildRequest>()
                .Register(context);

            container
                .RequestRegistrationFor<IAddCommentToBuildCommand>()
                .LatestRequest<AddCommentToBuildCommand>()
                .Register(context);

            container
                .RequestRegistrationFor<IGetLabelsOfBuildRequest>()
                .LatestRequest<GetLabelsOfBuildRequest>()
                .Register(context);

            container
                .RequestRegistrationFor<IAddLabelToBuildCommand>()
                .LatestRequest<AddLabelToBuildCommand>()
                .Register(context);

            container
                .RequestRegistrationFor<IDeleteLabelOfBuildCommand>()
                .LatestRequest<DeleteLabelOfBuildCommand>()
                .Register(context);

            container.RegisterType<IBuildStateParameterAspect, BuildStateParameterAspect>();
            container.RegisterType<ILabelFilterParameterAspect, LabelFilterParameterAspect>();
            container.RegisterType<IIssueFilterParameterAspect, IssueFilterParameterAspect>();
            container.RegisterType<IGetBuildsOfPlanParameterAspect, GetBuildsOfPlanParameterAspect>();
            container.RegisterType<IGetInformationOfBuildParameterAspect, GetInformationOfBuildParameterAspect>();
            container.RegisterType<IBuildRequestBuilderFactory, BuildRequestBuilderFactory>();
        }
    }
}