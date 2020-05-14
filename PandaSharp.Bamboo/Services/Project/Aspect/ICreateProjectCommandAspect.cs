namespace PandaSharp.Bamboo.Services.Project.Aspect
{
    internal interface ICreateProjectCommandAspect
    {
        string ProjectKey { get; set; }

        string ProjectName { get; set; }

        string Description { get; set; }

        bool EnablePublicAccess { get; set; }
    }
}