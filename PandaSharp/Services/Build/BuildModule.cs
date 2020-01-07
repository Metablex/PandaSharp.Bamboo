using PandaSharp.IoC;
using PandaSharp.IoC.Contract;
using PandaSharp.Services.Build.Aspect;
using PandaSharp.Services.Build.Contract;
using PandaSharp.Services.Build.Factory;
using PandaSharp.Services.Build.Request;
using PandaSharp.Utils;

namespace PandaSharp.Services.Build
{
    internal sealed class BuildModule : PandaContextModuleBase
    {
        public override void RegisterModule(IPandaContainer container, PandaContainerContext context)
        {
            container
                .RequestRegistrationFor<IBuildListRequest>()
                .LatestRequest<BuildListRequest>()
                .Register(context);

            container
                .RequestRegistrationFor<IBuildRequest>()
                .LatestRequest<BuildRequest>()
                .Register(context);

            container.RegisterType<IBuildStateParameterAspect, BuildStateParameterAspect>();
            container.RegisterType<ILabelFilterParameterAspect, LabelFilterParameterAspect>();
            container.RegisterType<IIssueFilterParameterAspect, IssueFilterParameterAspect>();
            container.RegisterExpandStateParameterAspect<BuildListExpandState>();
            container.RegisterExpandStateParameterAspect<BuildExpandState>();

            container.RegisterType<IBuildRequestBuilderFactory, BuildRequestBuilderFactory>();
        }
    }
}