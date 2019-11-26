using PandaSharp.IoC.Contract;
using PandaSharp.Services.Build.Aspect;
using PandaSharp.Services.Build.Contract;
using PandaSharp.Services.Build.Factory;
using PandaSharp.Services.Build.Request;
using PandaSharp.Utils;

namespace PandaSharp.Services.Build
{
    internal static class BuildModule
    {
        public static void RegisterBuildModule(this IPandaContainer container)
        {
            container.RegisterType<IBuildStateParameterAspect, BuildStateParameterAspect>();
            container.RegisterType<ILabelFilterParameterAspect, LabelFilterParameterAspect>();
            container.RegisterType<IIssueFilterParameterAspect, IssueFilterParameterAspect>();
            container.RegisterExpandStateParameterAspect<BuildsExpandState>();
            container.RegisterExpandStateParameterAspect<BuildExpandState>();

            container.RegisterType<IBuildsRequest, BuildsRequest>();
            container.RegisterType<IBuildRequest, BuildRequest>();

            container.RegisterType<IBuildRequestBuilderFactory, BuildRequestBuilderFactory>();
        }
    }
}