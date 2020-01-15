using PandaSharp.Bamboo.IoC;
using PandaSharp.Bamboo.IoC.Contract;
using PandaSharp.Bamboo.Services.Build.Aspect;
using PandaSharp.Bamboo.Services.Build.Contract;
using PandaSharp.Bamboo.Services.Build.Factory;
using PandaSharp.Bamboo.Services.Build.Request;
using PandaSharp.Bamboo.Services.Build.Types;
using PandaSharp.Bamboo.Utils;

namespace PandaSharp.Bamboo.Services.Build
{
    internal sealed class BuildModule : PandaContextModuleBase
    {
        public override void RegisterModule(IPandaContainer container, PandaContainerContext context)
        {
            container
                .RequestRegistrationFor<IMultipleBuildsRequest>()
                .LatestRequest<MultipleBuildsRequest>()
                .Register(context);

            container
                .RequestRegistrationFor<ISingleBuildRequest>()
                .LatestRequest<SingleBuildRequest>()
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