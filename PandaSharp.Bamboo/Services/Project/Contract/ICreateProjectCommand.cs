using PandaSharp.Bamboo.Services.Common.Contract;

namespace PandaSharp.Bamboo.Services.Project.Contract
{
    public interface ICreateProjectCommand : ICommandBase
    {
        ICreateProjectCommand WithDescription(string description);

        ICreateProjectCommand EnablePublicAccess();
    }
}