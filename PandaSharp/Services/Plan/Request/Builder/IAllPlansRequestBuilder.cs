using PandaSharp.Services.Common;
using PandaSharp.Services.Plan.Response;

namespace PandaSharp.Services.Plan.Request.Builder
{
    public interface IAllPlansRequestBuilder : IRequestBuilderBase<AllPlansResponse>
    {
        IAllPlansRequestBuilder WithMaxResult(int maxResult);

        IAllPlansRequestBuilder StartAtIndex(int startIndex);

        IAllPlansRequestBuilder IncludeDetails();

        IAllPlansRequestBuilder IncludeDetailsAndActions();
    }
}
