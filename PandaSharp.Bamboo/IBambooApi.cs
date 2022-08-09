using PandaSharp.Bamboo.Services.Build.Factory;
using PandaSharp.Bamboo.Services.Plan.Factory;
using PandaSharp.Bamboo.Services.Project.Factory;
using PandaSharp.Bamboo.Services.Search.Factory;
using PandaSharp.Bamboo.Services.Users.Factory;

namespace PandaSharp.Bamboo
{
    public interface IBambooApi
    {
        IProjectRequestBuilderFactory ProjectRequest { get; }
        
        IPlanRequestBuilderFactory PlanRequest { get; }
        
        IBuildRequestBuilderFactory BuildRequest { get; }
        
        IUsersRequestBuilderFactory UsersRequest { get; }
        
        ISearchRequestBuilderFactory SearchRequest { get; }
    }
}