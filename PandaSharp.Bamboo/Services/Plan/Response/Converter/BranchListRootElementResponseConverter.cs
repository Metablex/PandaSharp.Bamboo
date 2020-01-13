using PandaSharp.Bamboo.Services.Common.Response.Converter;

namespace PandaSharp.Bamboo.Services.Plan.Response.Converter
{
    internal class BranchListRootElementResponseConverter : RootElementResponseConverterBase<BranchListResponse, BranchResponse>
    {
        protected override string RootElement => "branches";
    }
}