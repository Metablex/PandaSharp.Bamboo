using PandaSharp.Bamboo.Services.Plan.Aspect;
using PandaSharp.Bamboo.Services.Plan.Contract;
using PandaSharp.Bamboo.Services.Plan.Factory;
using PandaSharp.Bamboo.Services.Plan.Request;
using PandaSharp.Framework.IoC.Contract;

namespace PandaSharp.Bamboo.Services.Plan
{
    internal sealed class PlanModule : IPandaContainerModule
    {
        public void RegisterModule(IPandaContainer container)
        {
            container.RegisterType<IGetAllPlansRequest, GetAllPlansRequest>();
            container.RegisterType<IGetInformationOfPlanRequest, GetInformationOfPlanRequest>();
            container.RegisterType<IGetBranchesOfPlanRequest, GetBranchesOfPlanRequest>();
            container.RegisterType<IGetArtifactsOfPlanRequest, GetArtifactsOfPlanRequest>();
            container.RegisterType<IEnableDisablePlanCommand, EnableDisablePlanCommand>();
            container.RegisterType<IDeletePlanCommand, DeletePlanCommand>();
            container.RegisterType<ICreatePlanCommand, CreatePlanCommand>();
            container.RegisterType<IGetLabelsOfPlanRequest, GetLabelsOfPlanRequest>();
            container.RegisterType<IAddLabelToPlanCommand, AddLabelToPlanCommand>();
            container.RegisterType<IDeleteLabelOfPlanCommand, DeleteLabelOfPlanCommand>();
            container.RegisterType<IGetVcsBranchesOfPlanRequest, GetVcsBranchesOfPlanRequest>();
            container.RegisterType<IFavouritePlanCommand, FavouritePlanCommand>();
            container.RegisterType<IGetBranchesOfPlanParameterAspect, GetBranchesOfPlanParameterAspect>();
            container.RegisterType<ICreatePlanParameterAspect, CreatePlanParameterAspect>();
            container.RegisterType<IGetAllPlansParameterAspect, GetAllPlansParameterAspect>();
            container.RegisterType<IGetInformationOfPlanParameterAspect, GetInformationOfPlanParameterAspect>();
            container.RegisterType<IPlanRequestBuilderFactory, PlanRequestBuilderFactory>();
        }
    }
}
