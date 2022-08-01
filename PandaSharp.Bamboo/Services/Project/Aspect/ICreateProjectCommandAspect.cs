namespace PandaSharp.Bamboo.Services.Project.Aspect
{
    internal interface ICreateProjectCommandAspect
    {
        void SetProjectKey(string projectKey);
        
        void SetProjectName(string projectName);
        
        void SetDescription(string description);
        
        void EnablePublicAccess(bool enablePublicAccess);
    }
}