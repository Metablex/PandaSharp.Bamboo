namespace PandaSharp.Bamboo.Services.Project.Aspect
{
    internal interface IGetAllProjectsParameterAspect
    {
        bool IncludeEmptyProjects { get; set; }

        bool IncludePlanInformation { get; set; }
    }
}