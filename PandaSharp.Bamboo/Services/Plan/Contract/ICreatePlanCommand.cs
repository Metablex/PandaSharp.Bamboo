using PandaSharp.Framework.Services.Contract;

namespace PandaSharp.Bamboo.Services.Plan.Contract
{
    public interface ICreatePlanCommand : ICommandBase
    {
        ICreatePlanCommand WithVcsBranch(string vcsBranch);

        ICreatePlanCommand WithEnabledState(bool isEnabled);

        ICreatePlanCommand WithCleanupEnabled(bool isCleanupEnabled);
    }
}