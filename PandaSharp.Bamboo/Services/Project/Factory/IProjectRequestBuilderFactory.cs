using PandaSharp.Bamboo.Services.Project.Contract;

namespace PandaSharp.Bamboo.Services.Project.Factory
{
    public interface IProjectRequestBuilderFactory
    {
        IGetAllProjectsRequest GetAllProjects();

        ICreateProjectCommand CreateProject(string projectKey, string projectName);

        IDeleteProjectCommand DeleteProject(string projectKey);

        IGetInformationOfProjectRequest GetInformationOfProject(string projectKey);
    }
}