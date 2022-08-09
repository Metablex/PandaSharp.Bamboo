using PandaSharp.Bamboo.Services.Build.Factory;
using PandaSharp.Bamboo.Services.Plan.Factory;
using PandaSharp.Bamboo.Services.Project.Factory;
using PandaSharp.Bamboo.Services.Search.Factory;
using PandaSharp.Bamboo.Services.Users.Factory;

namespace PandaSharp.Bamboo.Services.Common
{
    internal sealed class BambooApi : IBambooApi
    {
        public IProjectRequestBuilderFactory ProjectRequest { get; }
        
        public IPlanRequestBuilderFactory PlanRequest { get; }
        
        public IBuildRequestBuilderFactory BuildRequest { get; }
        
        public IUsersRequestBuilderFactory UsersRequest { get; }
        
        public ISearchRequestBuilderFactory SearchRequest { get; }

        public BambooApi(
            IProjectRequestBuilderFactory projectRequestBuilderFactory,
            IPlanRequestBuilderFactory planRequestBuilderFactory,
            IBuildRequestBuilderFactory buildRequestBuilderFactory,
            IUsersRequestBuilderFactory usersRequestBuilderFactory,
            ISearchRequestBuilderFactory searchRequestBuilderFactory)
        {
            ProjectRequest = projectRequestBuilderFactory;
            PlanRequest = planRequestBuilderFactory;
            BuildRequest = buildRequestBuilderFactory;
            UsersRequest = usersRequestBuilderFactory;
            SearchRequest = searchRequestBuilderFactory;
        }
    }
}
